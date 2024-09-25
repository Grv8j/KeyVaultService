using KeyVaultService.Persistence.Entities.Interfaces;

namespace KeyVaultService.Persistence.Entities;

/// <summary>
/// Secret value entity
/// </summary>
public class SecretValue : IEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Secret id
    /// </summary>
    public Guid SecretId { get; set; }
    
    /// <summary>
    /// Secret navigation edge
    /// </summary>
    public Secret Secret { get; set; }

    /// <summary>
    /// Expiration date
    /// </summary>
    public DateOnly? ExpirationDate { get; set; }

    /// <summary>
    /// Activation date
    /// </summary>
    public DateOnly? ActivationDate { get; set; }

    /// <summary>
    /// Flag ig secret is enabled
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary>
    /// Bytes array of value
    /// </summary>
    public byte[] Value { get; set; }
    
    /// <summary>
    /// Collection of secret value logs
    /// </summary>
    public ICollection<SecretValueLog> SecretValueLogs { get; set; }
}
