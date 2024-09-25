using KeyVaultService.Framework.Dependency;
using KeyVaultService.Framework.Result;
using KeyVaultService.Interface.Models;
using KeyVaultService.Interface.Query;
using KeyVaultService.Interface.Services;

namespace KeyVaultService.Logic.Services;

/// <summary>
/// Vault secrets query service
/// </summary>
[RegisterService(typeof(IVaultSecretsQueryService), EServiceLifetime.Transient)]
internal class VaultSecretsQueryService : IVaultSecretsQueryService
{
    /// <inheritdoc cref="IVaultSecretsQueryService.GetSecretsForVault"/>
    public IServiceResultWrapper<VmVaultSecrets> GetSecretsForVault(VmGetVaultSecretsByIdQuery query)
    {
        return ServiceResultWrapperProvider.CreateWrapper(new VmVaultSecrets());
    }
}