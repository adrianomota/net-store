namespace NetStore.Api.Configurations;
public static class RedisConfiguration
{
    public static void AddRedisConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var redisConnectionString = configuration["Redis:ConnectionString"];
        services.AddStackExchangeRedisCache(option =>
        {
            option.Configuration = redisConnectionString;
        });
    }
}
