namespace NetStore.Catalog.IoC;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionConfig
{
    public static void AddCatalogDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if(services == null) throw new ArgumentException(message: $"Description error: {nameof(services)}");
        NativeInjectorBootStrapper.RegisterServices(services, configuration);
    }
}
