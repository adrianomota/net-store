namespace NetStore.Api.Configurations;

public static class AppSettingsConfiguration
{
    public static IConfigurationBuilder AddAppSettingsConfiguration(this IConfigurationBuilder config, WebApplicationBuilder builder)
    {
        config
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
            return config;
    }
}
