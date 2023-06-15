namespace NetStore.Catalog.IoC;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetStore.Catalog.Application.Contracts;
using NetStore.Catalog.Application.Services;
using NetStore.Catalog.Domain.Contracts;
using NetStore.Catalog.Infrastructure;
using NetStore.Catalog.Infrastructure.Contracts;
using NetStore.Core.Dispatcher;

public static class NativeInjectorBootStrapper
{
   public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
   {
        services.AddOptions<DbOptions>()
         .Configure<IConfiguration>((settings, configuration) => configuration.GetSection("DbOptions").Bind(settings));

        services.AddScoped<IMediatrHandler, MediatrHandler>();
        services.AddScoped<IProductAppService, ProductAppService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<CatalogDbContext>();

      
   }
}
