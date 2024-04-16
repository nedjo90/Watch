using Contracts;
using Main.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


#pragma warning disable CS0618 // Type or member is obsolete
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
#pragma warning restore CS0618 // Type or member is obsolete

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers(configure =>
    {
        configure.RespectBrowserAcceptHeader = true;
        configure.ReturnHttpNotAcceptable = true;
    })
    .AddXmlDataContractSerializerFormatters()
    .AddApplicationPart(typeof(Main.Presentation.AssemblyReference).Assembly);

WebApplication app = builder.Build();

ILoggerManager logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

if (app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});



app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();
