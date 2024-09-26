namespace KeyVaultService.Logic.Configuration;

/// <summary>
/// Cryptographic configuration interface
/// </summary>
public interface ICryptographicConfiguration
{
    /// <summary>
    /// Size in bits of secret key
    /// </summary>
    int KeySize { get; }
    
    /// <summary>
    /// Size in bit of the block
    /// </summary>
    int BlockSize { get; }
    
    /// <summary>
    /// Symmetrical key of the consumer
    /// </summary>
    string SymmetricalKey { get; }
}