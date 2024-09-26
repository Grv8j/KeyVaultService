using System.Security.Cryptography;
using FluentAssertions;
using KeyVaultService.Logic.Configuration;
using KeyVaultService.Logic.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using ConfigurationSection = Microsoft.Extensions.Configuration.ConfigurationSection;

namespace KeyVaultService.Tests;


/// <summary>
/// Tests for encryption service
/// </summary>
public class EncryptionServiceTests
{
    private CryptographicService? CryptographicService;
    private CryptographicConfiguration? Configuration;

    [SetUp]
    public void Init()
    {
        var confMock = new Mock<IConfiguration>();
        confMock.Setup(x => x.GetSection(It.IsAny<string>()))
            .Returns(new ConfigurationSection(
                new ConfigurationRoot(
                    new List<IConfigurationProvider>()), string.Empty));
        
        Configuration = new Mock<CryptographicConfiguration>(confMock.Object).Object;
        Configuration.BlockSize = 128;
        Configuration.KeySize = 256;
        Configuration.SymmetricalKey = "86862103251525332820946560205810";
        
        CryptographicService = new CryptographicService(Configuration);
    }
    
    [Test]
    public void EncryptedPasswordWillBeDecryptedSuccessfully()
    {
        var passwd = "password";
        var passwordEncrypted = CryptographicService!.EncryptValue(passwd);
        var decryptedPassword = CryptographicService.DecryptValue(passwordEncrypted);

        decryptedPassword.Should().Be(passwd); 
    }
    
    [Test]
    public void EncryptedPasswordWillBeDecryptedWithChangedKeyAndThrowsException()
    {
        var passwd = "password";
        var passwordEncrypted = CryptographicService!.EncryptValue(passwd);
        
        Configuration!.SymmetricalKey = "29878068079709434684217551393176";
        CryptographicService = new CryptographicService(Configuration);
        
        Assert.Throws<CryptographicException>(() => CryptographicService.DecryptValue(passwordEncrypted));
    }
}