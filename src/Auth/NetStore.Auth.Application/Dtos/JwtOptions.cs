namespace NetStore.Auth.Application.Dtos;

public class JwtOptions
{
    public string? Audience { get; set; }
    public string? Issuer { get; set; }
    public int Hours { get; set; }
}
