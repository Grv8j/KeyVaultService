using KeyVaultService.Framework.Result;
using KeyVaultService.Interface.Models;
using KeyVaultService.Interface.Query;

namespace KeyVaultService.Interface.Services;

/// <summary>
/// Vault secrets query service interface
/// </summary>
public interface IVaultSecretsQueryService
{
    /// <summary>
    /// Gets all secrets available for vault
    /// </summary>
    /// <param name="query"><inheritdoc cref="VmGetVaultSecretsByIdQuery"/></param>
    /// <returns><inheritdoc cref="VmVaultSecrets"/></returns>
    IServiceResultWrapper<VmVaultSecrets> GetSecretsForVault(VmGetVaultSecretsByIdQuery query);
}