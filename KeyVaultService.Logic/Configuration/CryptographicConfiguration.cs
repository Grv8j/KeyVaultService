using KeyVaultService.Framework.Dependency;
using Microsoft.Extensions.Configuration;

namespace KeyVaultService.Logic.Configuration;

/// <summary>
/// Cryptographic configuration
/// </summary>
[RegisterService(typeof(ICryptographicConfiguration), EServiceLifetime.Singleton)]
public class CryptographicConfiguration : ICryptographicConfiguration
{
    private const string CRYPTOGRAPHIC_CONFIGURATION_SECTION_KEY = "CryptographicConfiguration";
    
    /// <summary>
    /// C-tor
    /// </summary>
    /// <param name="configuration">Configuration</param>
    public CryptographicConfiguration(IConfiguration configuration)
    {
        configuration.GetSection(CRYPTOGRAPHIC_CONFIGURATION_SECTION_KEY).Bind(this);
    }
    
    /// <inheritdoc cref="ICryptographicConfiguration.KeySize"/>
    public int KeySize { get; set; }
    
    /// <inheritdoc cref="ICryptographicConfiguration.BlockSize"/>
    public int BlockSize { get; set; }

    /// <inheritdoc cref="ICryptographicConfiguration.SymmetricalKey"/>
    public string SymmetricalKey { get; set; } = string.Empty;
}