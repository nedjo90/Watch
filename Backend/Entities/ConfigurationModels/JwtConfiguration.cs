namespace Entities.ConfigurationModels;

public class JwtConfiguration
{
    public string Section { get; set; } = "JwtSettings";
    public string? ValidIssuer { get; set; }
    public string? ValidAudience { get; set; }
    public string? Secret { get; set; }
    public double AccessTokenDurationTime { get; set; }
    
    public double RefreshTokenDurationTime { get; set; }
}