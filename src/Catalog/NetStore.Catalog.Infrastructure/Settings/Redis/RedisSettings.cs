namespace NetStore.Catalog.Infrastructure.Settings.Redis;

public class RedisSettings
{
    public Dictionary<string, List<RedisConfigurationValue>> Scopes { get; set; }
    public RedisConfigurationValue this[string scope,string key] 
    { 
        get 
        {
            return Scopes[scope].First(value=> value.Key == key);
        } 
    }

}
