namespace KeyVaultService.Interface.Services;

/// <summary>
/// Secrets validation helper service interface 
/// </summary>
public interface ISecretsValidationHelperService
{
    /// <summary>
    /// Checks if vault with this id exists in database
    /// </summary>
    /// <param name="vaultId">Vault id</param>
    /// <returns>True if exists, otherwise false</returns>
    bool DoesVaultExist(Guid vaultId);
}