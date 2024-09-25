namespace KeyVaultService.Persistence.Entities;

/// <summary>
/// Secret entity
/// </summary>
public class Secret
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Vault id
    /// </summary>
    public Guid VaultId { get; set; }
    
    /// <summary>
    /// Connected vault
    /// </summary>
    public Vault Vault { get; set; }

    /// <summary>
    /// Secret name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Creation time
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Created by
    /// </summary>
    public string CreatedBy { get; set; }

    /// <summary>
    /// Collection of secret value logs
    /// </summary>
    public ICollection<SecretValueLog> SecretValueLogs { get; set; }

    /// <summary>
    /// Collection of secret values
    /// </summary>
    public ICollection<SecretValue> SecretValues { get; set; }
}
