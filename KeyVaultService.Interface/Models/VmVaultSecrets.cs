using KeyVaultService.Interface.Query;

namespace KeyVaultService.Interface.Models;

/// <summary>
/// Vault secrets view model
/// </summary>
public class VmVaultSecrets : VmBase
{
    /// <summary>
    /// Vault id
    /// </summary>
    public Guid VaultId { get; set; }
    
    /// <summary>
    /// Collection of vault secrets
    /// </summary>
    public ICollection<VmVaultSecrets> VaultSecrets { get; set; } = new List<VmVaultSecrets>();
}