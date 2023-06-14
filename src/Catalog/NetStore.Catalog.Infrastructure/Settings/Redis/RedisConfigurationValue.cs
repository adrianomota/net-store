namespace NetStore.Catalog.Infrastructure.Settings.Redis;

public class RedisConfigurationValue
{
    public string Key { get; set; }
    public long ExpirationInMinutes { get; set; }    
}
