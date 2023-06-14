namespace NetStore.Catalog.IoC;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetStore.Catalog.Application.Contracts;
using NetStore.Catalog.Application.Services;
using NetStore.Catalog.Domain.Contracts;
using NetStore.Catalog.Infrastructure;

public static class NativeInjectorBootStrapper
{
   public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
   {
        #region Services
        services.AddScoped<IProductAppService, ProductAppService>();
        #endregion

        #region Repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        #endregion

        services.AddDbContext<CatalogContext>(optionsAction: options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        #region Settings
            
        #endregion    
   }
}
