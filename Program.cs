using GMS2025.Business.Generators;
using Microsoft.AspNetCore.Mvc.Razor;
using Umbraco.Cms.Infrastructure.ModelsBuilder.Building;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var environmentName = builder.Environment.EnvironmentName;
builder.Configuration.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);
builder.Configuration.GetConnectionString("umbracoDbDSN");

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    .Build();

builder.Services.AddSingleton<IModelsGenerator, CustomModelsGenerator>();

WebApplication app = builder.Build();

// Register the global service provider
StaticServiceProvider.Instance = app.Services;

await app.BootUmbracoAsync();

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();