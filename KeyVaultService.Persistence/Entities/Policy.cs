using KeyVaultService.Persistence.Entities.Interfaces;

namespace KeyVaultService.Persistence.Entities;

/// <summary>
/// Policy entity
/// </summary>
public class Policy : IEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Policy name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Collection of vault policies which have policy assigned
    /// </summary>
    public ICollection<VaultPolicy> VaultPolicies { get; set; }
}
