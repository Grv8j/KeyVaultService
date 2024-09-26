using KeyVaultService.Framework.Managers;
using KeyVaultService.Interface.Command;
using KeyVaultService.Persistence.Entities;
using Nelibur.ObjectMapper;

namespace KeyVaultService.Logic.Mapping.Persistence;

/// <summary>
/// Mapping for <inheritdoc cref="VmCreateSecretCommand"/> to <inheritdoc cref="Secret"/>
/// </summary>
public class CreateSecretCommandMapping : IMapper
{
    /// <inheritdoc cref="IMapper.Map"/>
    public void Map()
    {
        TinyMapper.Bind<VmCreateSecretCommand, Secret>(cfg =>
        {
            cfg.Bind(s => s.VaultId, d => d.VaultId);
            cfg.Bind(s => s.Name, d => d.Name);
            cfg.Ignore(s => s.Value);
        });
        
        TinyMapper.Bind<VmCreateSecretCommand, SecretValue>(cfg =>
        {
            cfg.Bind(s => s.IsEnabled, d => d.IsEnabled);
            cfg.Bind(s => s.ActivationDate, d => d.ActivationDate);
            cfg.Bind(s => s.ExpirationDate, d => d.ExpirationDate);
            cfg.Ignore(s => s.Value);
        });
    }
}