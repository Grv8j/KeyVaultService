namespace KeyVaultService.Interface.Query;

/// <summary>
/// Query to get vault secrets by vault id
/// </summary>
public class VmGetVaultSecretsByIdQuery : VmBase
{
    /// <summary>
    /// Vault id
    /// </summary>
    public Guid VaultId { get; set; }
}