using KeyVaultService.Framework.Managers;
using KeyVaultService.Interface.Models;
using KeyVaultService.Persistence.Entities;
using Nelibur.ObjectMapper;

namespace KeyVaultService.Logic.Mapping.Models;

/// <summary>
/// Secret entity to secret view model mapping
/// </summary>
public class SecretToVmMapping : IMapper
{
    /// <inheritdoc cref="IMapper.Map"/>
    public void Map()
    {
        TinyMapper.Bind<Secret, VmSecret>(cfg =>
        {
            cfg.Bind(s => s.Id, d => d.Id);
            cfg.Bind(s => s.Name, d => d.Name);
            cfg.Bind(s => s.CreatedBy, d => d.CreatedBy);
            cfg.Bind(s => s.Created, d => d.Created);
        });
    }
}