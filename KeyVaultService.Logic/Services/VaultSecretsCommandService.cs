using KeyVaultService.Framework.Dependency;
using KeyVaultService.Framework.Result;
using KeyVaultService.Interface;
using KeyVaultService.Interface.Command;
using KeyVaultService.Interface.Services;
using KeyVaultService.Persistence.AccessManager;
using KeyVaultService.Persistence.Entities;
using Nelibur.ObjectMapper;

namespace KeyVaultService.Logic.Services;

/// <summary>
/// Vault secrets command service
/// </summary>
[RegisterService(typeof(IVaultSecretsCommandService), EServiceLifetime.Transient)]
internal class VaultSecretsCommandService(
    ICryptographicService cryptographicService,
    IVaultPersistenceAccessManager persistenceAccessManager) : IVaultSecretsCommandService
{
    /// <inheritdoc cref="IVaultSecretsCommandService.CreateSecret"/>
    public IServiceResultWrapper<VmIdentifier> CreateSecret(VmCreateSecretCommand command)
    {
        var encryptedValue = cryptographicService.EncryptValue(command.Value);

        var secretEntity = TinyMapper.Map<Secret>(command);
        var secretValueEntity = TinyMapper.Map<SecretValue>(command);

        secretEntity.Id = Guid.NewGuid();
        secretValueEntity.Id = Guid.NewGuid();
        secretValueEntity.Value = encryptedValue;
        
        secretValueEntity.SecretId = secretEntity.Id;
        secretEntity.SecretValues = [ secretValueEntity ];

        secretEntity.Created = DateTime.UtcNow;
        secretEntity.CreatedBy = Constants.CREATED_BY_DEFAULT;

        var id = persistenceAccessManager.ExecuteWriter(unitOfWork =>
        {
            unitOfWork.GetRepository<Secret>()
                .Add(secretEntity);

            unitOfWork.SaveChanges();

            return secretEntity.Id;
        });

        return ServiceResultWrapperProvider.CreateWrapper(
            new VmIdentifier
            {
                Id = id
            });
    }
}