namespace KeyVaultService.Persistence.Entities;

/// <summary>
/// Vault policy entity
/// </summary>
public class VaultPolicy
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Policy id
    /// </summary>
    public Guid PolicyId { get; set; }
    
    /// <summary>
    /// Policy navigation edge
    /// </summary>
    public Policy Policy { get; set; }

    /// <summary>
    /// Vault id
    /// </summary>
    public Guid VaultId { get; set; }
    
    /// <summary>
    /// Vault navigation edge
    /// </summary>
    public Vault Vault { get; set; }

    /// <summary>
    /// OAuthenticated object(user) id
    /// </summary>
    public Guid ObjectId { get; set; }
}
