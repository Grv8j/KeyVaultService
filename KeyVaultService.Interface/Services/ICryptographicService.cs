namespace KeyVaultService.Interface.Services;

/// <summary>
/// Cryptographic service interface
/// </summary>
public interface ICryptographicService
{
    /// <summary>
    /// Encrypts value
    /// </summary>
    /// <param name="value">Value to encrypt</param>
    /// <returns>Encrypted byte array</returns>
    byte[] EncryptValue(string value);
    
    /// <summary>
    /// Decrypts values from byte array
    /// </summary>
    /// <param name="bytes">Encrypted byte array</param>
    /// <returns>Value</returns>
    string DecryptValue(byte[] bytes);
}