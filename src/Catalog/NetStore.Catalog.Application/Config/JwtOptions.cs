namespace NetStore.Catalog.Application.Config;

public class JwtOptions
{   
    public string? Audience { get; set; }
    public string? Hours { get; set; }
    public string? Issuer { get; set; }
    public string Secret { get { return "fedaf7d8863b48e197b9287d492b708e"; }}
}
