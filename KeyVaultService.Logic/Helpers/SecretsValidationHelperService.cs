using KeyVaultService.Framework.Dependency;
using KeyVaultService.Interface.Services;
using KeyVaultService.Persistence.AccessManager;
using KeyVaultService.Persistence.Entities;

namespace KeyVaultService.Logic.Helpers;

/// <summary>
/// Secrets validation helper service
/// </summary>
/// <param name="persistenceAccessManager">Persistence access manager</param>
[RegisterService(typeof(ISecretsValidationHelperService), EServiceLifetime.Transient)]
internal class SecretsValidationHelperService(
    IVaultPersistenceAccessManager persistenceAccessManager) : ISecretsValidationHelperService
{
    /// <inheritdoc cref="ISecretsValidationHelperService.DoesVaultExist"/>
    public bool DoesVaultExist(Guid vaultId) =>
        vaultId != Guid.Empty && persistenceAccessManager.ExecuteReader(unitOfWork
            => unitOfWork.GetRepository<Vault>()
                .Exists(x => x.Id == vaultId));
}