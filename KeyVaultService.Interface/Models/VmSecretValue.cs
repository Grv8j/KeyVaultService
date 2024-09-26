using System.ComponentModel.DataAnnotations.Schema;

namespace KeyVaultService.Interface.Models;

/// <summary>
/// Secret value view model
/// </summary>
public class VmSecretValue
{
    /// <summary>
    /// Secret value id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Flag if secret is enabled or not
    /// </summary>
    public bool IsEnabled { get; set; }
    
    /// <summary>
    /// Expiration date
    /// </summary>
    public DateTime ExpirationDate { get; set; }
    
    /// <summary>
    /// Activation date
    /// </summary>
    public DateTime ActivationDate { get; set; }
    
    /// <summary>
    /// Decrypted value
    /// </summary>
    public string Value { get; set; }
}