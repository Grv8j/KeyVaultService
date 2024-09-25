using KeyVaultService.Persistence.Entities.Interfaces;

namespace KeyVaultService.Persistence.Entities;

/// <summary>
/// Vault entity
/// </summary>
public class Vault : IEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Vault name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Flag if vault is deleted
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Collection of secrets connected to vault
    /// </summary>
    public ICollection<Secret> Secrets { get; set; }

    /// <summary>
    /// Collection Vault policies
    /// </summary>
    public ICollection<VaultPolicy> VaultPolicies { get; set; }
}
