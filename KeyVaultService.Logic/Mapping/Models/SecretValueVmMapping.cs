using KeyVaultService.Framework.Managers;
using KeyVaultService.Interface.Models;
using KeyVaultService.Persistence.Entities;
using Nelibur.ObjectMapper;

namespace KeyVaultService.Logic.Mapping.Models;

/// <summary>
/// Secret value to view model mapping
/// </summary>
public class SecretValueVmMapping : IMapper
{
    /// <inheritdoc cref="IMapper.Map"/>
    public void Map()
    {
        TinyMapper.Bind<SecretValue, VmSecretValue>(cfg =>
        {
            cfg.Bind(s => s.Id, d => d.Id);
            cfg.Bind(s => s.IsEnabled, d => d.IsEnabled);
            cfg.Bind(s => s.ExpirationDate, d => d.ExpirationDate);
            cfg.Bind(s => s.ActivationDate, d => d.ActivationDate);
            cfg.Ignore(s => s.Value);
        });
    }
}