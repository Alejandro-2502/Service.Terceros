using Terceros.Services.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

IWebHostEnvironment _env = builder.Environment;
var configutationBuilder = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile($"appsettings.{_env.EnvironmentName.ToUpper()}.json", optional: true)
    .AddEnvironmentVariables();


IConfiguration configuration = configutationBuilder.Build();
services.Configure(builder, configuration);

var app = builder.Build();
app.Configure();
app.Run();