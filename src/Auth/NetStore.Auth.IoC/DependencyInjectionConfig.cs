namespace NetStore.Auth.IoC;

using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionConfig
{
    public static void AddAuthDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if(services == null) throw new ArgumentException(message: $"Description error: {nameof(services)}");
        NativeInjectorBootStrapper.RegisterServices(services);
    }
}
