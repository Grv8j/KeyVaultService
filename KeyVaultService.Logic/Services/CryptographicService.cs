using System.Security.Cryptography;
using System.Text;
using KeyVaultService.Framework.Dependency;
using KeyVaultService.Interface.Services;
using KeyVaultService.Logic.Configuration;

namespace KeyVaultService.Logic.Services;

/// <summary>
/// Cryptographic service
/// </summary>
[RegisterService(typeof(ICryptographicService), EServiceLifetime.Scoped)]
internal class CryptographicService(ICryptographicConfiguration cryptographicConfiguration) : ICryptographicService
{
    /// <inheritdoc cref="ICryptographicService.EncryptValue"/>
    public byte[] EncryptValue(string value)
    {
        using (var aes = CreateAndInitAes())
        {
            aes.GenerateIV();
            
            using (var encryptor = aes.CreateEncryptor())
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(value);
                        }

                        return aes.IV.Concat(memoryStream.ToArray()).ToArray();
                    }
                }
            }
        }
    }

    /// <inheritdoc cref="ICryptographicService.DecryptValue"/>
    public string DecryptValue(byte[] bytes)
    {
        using var aes = CreateAndInitAes();
        // During encryption, we stored the unique IV in the first 16 bytes
        aes.IV = bytes.Take(16).ToArray();

        // The actual value to decrypt is the rest of the bytes after the stored IV.
        var encryptedValue = bytes.Skip(16).ToArray();

        using (var decryptor = aes.CreateDecryptor())
        {
            using (var ms = new MemoryStream(encryptedValue))
            {
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (var rdr = new StreamReader(cs))
                    {
                        return rdr.ReadToEnd();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Creates and initializes AES algorithm
    /// </summary>
    /// <returns><inheritdoc cref="System.Security.Cryptography.Aes"/></returns>
    private Aes CreateAndInitAes()
    {
        var aes = Aes.Create();
        aes.Padding = PaddingMode.PKCS7;
        aes.KeySize = cryptographicConfiguration.KeySize;
        aes.BlockSize = cryptographicConfiguration.BlockSize;
        aes.Key = Encoding.ASCII.GetBytes(cryptographicConfiguration.SymmetricalKey);
        
        return aes;
    }
}