namespace KeyVaultService.Interface.Command;

/// <summary>
/// Create secret command view model
/// </summary>
public class VmCreateSecretCommand
{
    /// <summary>
    /// Vault id
    /// </summary>
    public Guid VaultId { get; set; }

    /// <summary>
    /// Secret name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Secret value
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Activation date, non mandatory
    /// </summary>
    public DateTime? ActivationDate { get; set; }

    /// <summary>
    /// Expiration date, non mandatory
    /// </summary>
    public DateTime? ExpirationDate { get; set; }

    /// <summary>
    /// Flag if secret is enabled
    /// </summary>
    public bool IsEnabled { get; set; }
}