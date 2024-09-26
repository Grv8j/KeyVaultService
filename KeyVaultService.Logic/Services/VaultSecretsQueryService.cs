using KeyVaultService.Framework;
using KeyVaultService.Framework.Dependency;
using KeyVaultService.Framework.Result;
using KeyVaultService.Interface.Models;
using KeyVaultService.Interface.Query;
using KeyVaultService.Interface.Services;
using KeyVaultService.Persistence.AccessManager;
using KeyVaultService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;

namespace KeyVaultService.Logic.Services;

/// <summary>
/// Vault secrets query service
/// </summary>
[RegisterService(typeof(IVaultSecretsQueryService), EServiceLifetime.Transient)]
internal class VaultSecretsQueryService(
    IVaultPersistenceAccessManager persistenceAccessManager,
    ICryptographicService cryptographicService) : IVaultSecretsQueryService
{
    /// <inheritdoc cref="IVaultSecretsQueryService.GetSecretsForVault"/>
    public IServiceResultWrapper<VmVaultSecrets> GetSecretsForVault(VmGetVaultSecretsByIdQuery query)
    {
        var secrets = persistenceAccessManager.ExecuteReader(unitOfWork =>
        {
            return unitOfWork.GetRepository<Secret>()
                .GetQueryable()
                .Include(x => x.SecretValues)
                .Where(x => x.VaultId == query.VaultId)
                .ToList();
        });

        var secretsTranslated = secrets.Select(x =>
        {
            var vmSecret = TinyMapper.Map<VmSecret>(x);
            vmSecret.Values = x.SecretValues.Select(secVal =>
            {
                var vmSecVal = TinyMapper.Map<VmSecretValue>(secVal);
                vmSecVal.Value = cryptographicService.DecryptValue(secVal.Value);
                return vmSecVal;
            }).ToList();
            
            return vmSecret;
        }).ToList();
        
        return ServiceResultWrapperProvider.CreateWrapper(
            new VmVaultSecrets
            {
                VaultId = query.VaultId,
                VaultSecrets = secretsTranslated
            });
    }
}