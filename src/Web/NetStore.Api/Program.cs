using System.Reflection;
using NetStore.Api.Configurations;
using NetStore.Auth.IoC;
using NetStore.Catalog.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddAppSettingsConfiguration(builder);
builder.Services.AddAuthConfiguration(builder.Configuration);
builder.Services.AddApiConfiguration();
builder.Services.AddRedisConfiguration(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCatalogDependencyInjectionConfiguration(builder.Configuration);
builder.Services.AddAuthDependencyInjectionConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();
app.UseApiConfiguration(app.Environment);
app.Run();
