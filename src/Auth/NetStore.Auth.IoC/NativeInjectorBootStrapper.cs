namespace NetStore.Auth.IoC;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetStore.Auth.Application.Dtos;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddOptions<JwtOptions>()
            .Configure<IConfiguration>((settings, configuration) 
                => configuration.GetSection("JwtOptions").Bind(settings));
    }
}
