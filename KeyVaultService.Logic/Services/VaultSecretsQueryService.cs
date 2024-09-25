using KeyVaultService.Framework.Dependency;
using KeyVaultService.Framework.Result;
using KeyVaultService.Interface.Models;
using KeyVaultService.Interface.Query;
using KeyVaultService.Interface.Services;
using KeyVaultService.Persistence.AccessManager;
using KeyVaultService.Persistence.Entities;

namespace KeyVaultService.Logic.Services;

/// <summary>
/// Vault secrets query service
/// </summary>
[RegisterService(typeof(IVaultSecretsQueryService), EServiceLifetime.Transient)]
internal class VaultSecretsQueryService(
    IVaultPersistenceAccessManager persistenceAccessManager) : IVaultSecretsQueryService
{
    /// <inheritdoc cref="IVaultSecretsQueryService.GetSecretsForVault"/>
    public IServiceResultWrapper<VmVaultSecrets> GetSecretsForVault(VmGetVaultSecretsByIdQuery query)
    {
        var secrets = persistenceAccessManager.ExecuteReader(unitOfWork =>
        {
            return unitOfWork.GetRepository<Secret>()
                .Get(x => x.VaultId == query.VaultId)
                .ToList();
        });
        
        return ServiceResultWrapperProvider.CreateWrapper(new VmVaultSecrets());
    }
}