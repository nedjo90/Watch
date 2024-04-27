using System.Text;
using AspNetCoreRateLimit;
using Contracts;
using Entities.Models;
using LoggerService;
using Main.Utility;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Service;
using Service.Contracts;
using Service.DataShaping;

namespace Main.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen();
    }
    
    public static void ConfigureController(this IServiceCollection services)
    {
        services.AddControllers(configure =>
            {
                configure.RespectBrowserAcceptHeader = true;
                configure.ReturnHttpNotAcceptable = true;
                configure.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
                configure.CacheProfiles.ConfigureCacheProfile();
            })
            .AddXmlDataContractSerializerFormatters()
            .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
    }
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(
            options =>
            {
                options.AddPolicy(
                    "CorsPolicy",builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                        builder.WithExposedHeaders("X-Pagination");
                    }
                );
            }
        );
    }

    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(
            options =>
            {
                
            }
            );
    }

    public static void ConfigureLoggerService(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddScoped(typeof(IRepositoryManagerGeneric<>), typeof(RepositoryManagerGeneric<>));
    }

    public static void ConfigureServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped(typeof(IServiceManagerBasicGeneric<,,,>), typeof(ServiceManagerBasicGeneric<,,,>));
        services.AddScoped(typeof(IDataShaper<>), typeof(DataShaper<>));
        services.AddScoped(typeof(IBasicGenericLinks<>), typeof(BasicGenericLinks<>));
    }

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(optionsAction =>
            optionsAction.UseMySql(configuration.GetConnectionString("Default"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("Default")))
                );
    }
    
    public static void AddCustomMediaTypes(this IServiceCollection services)
    {
        services.Configure<MvcOptions>(config =>
        {
            SystemTextJsonOutputFormatter? systemTextJsonOutputFormatter = config.OutputFormatters
                .OfType<SystemTextJsonOutputFormatter>().FirstOrDefault();

            if (systemTextJsonOutputFormatter != null)
            {
                systemTextJsonOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.watch.hateoas+json");
                systemTextJsonOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.watch.apiroot+json");
            }
            
            XmlDataContractSerializerOutputFormatter? xmlOutputFormatter = config.OutputFormatters
                .OfType<XmlDataContractSerializerOutputFormatter>()
                .FirstOrDefault();

            if (xmlOutputFormatter != null)
            {
                xmlOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.watch.hateoas+xml");
                xmlOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.watch.apiroot+xml");
            }
        });
    }

    public static void ConfigureResponseCaching(this IServiceCollection services)
    {
        services.AddResponseCaching();
    }

    public static void ConfigureHttpCacheHeaders(this IServiceCollection services)
    {
        services.AddHttpCacheHeaders(
            expirationOption =>
        {
            expirationOption.MaxAge = 65;
            expirationOption.CacheLocation = CacheLocation.Private;
        },
        validationOption =>
        {
            validationOption.MustRevalidate = true;
        });
    }

    public static void ConfigureRateLimitingOptions(this IServiceCollection services)
    {
        List<RateLimitRule> rateLimitRules =
        [
            new RateLimitRule
            {
                Endpoint = "*",
                Limit = 1000,
                Period = "1h"
            }
        ];
        services.Configure<IpRateLimitOptions>(opt => 
        {
            opt.GeneralRules = rateLimitRules; 
        });
        services.AddSingleton<IRateLimitCounterStore,
        MemoryCacheRateLimitCounterStore>();
        services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        IdentityBuilder builder = services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 10;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();
    }

    public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {
        IConfigurationSection jwtSettings = configuration.GetSection("JwtSettings");
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["ValidIssuer"],
                    ValidAudience = jwtSettings["ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]!))
                };
            });
    }
    
    private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
    {
        return new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
            .Services.BuildServiceProvider()
            .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
            .OfType<NewtonsoftJsonPatchInputFormatter>().First();
    }

    private static void ConfigureCacheProfile(this IDictionary<string, CacheProfile> profile)
    {
        profile.Add("120SecondsDuration", new CacheProfile{Duration = 120});
    }
    
    
        
}