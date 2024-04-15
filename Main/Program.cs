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

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Main.Presentation.AssemblyReference).Assembly);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
{
    app.UseHsts();
}

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
