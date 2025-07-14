namespace Bookify.Infrastructre.Authentication;
public sealed class AuthenticationOptions
{
    public string Audience { get; set; } = string.Empty;
    public string MetadataUrl { get; set; } = string.Empty;
    public bool RequiredHttpMetadata { get; set; } 
    public string Issure { get; set; } = string.Empty;
}
