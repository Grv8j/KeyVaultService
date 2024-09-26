using KeyVaultService.Framework.Result;
using KeyVaultService.Interface.Command;

namespace KeyVaultService.Interface.Services;

/// <summary>
/// Vault secret command service interface
/// </summary>
public interface IVaultSecretsCommandService
{
    /// <summary>
    /// Creates new secret in a vault
    /// </summary>
    /// <param name="command"><inheritdoc cref="VmCreateSecretCommand"/></param>
    /// <returns>Id of created secret</returns>
    IServiceResultWrapper<VmIdentifier> CreateSecret(VmCreateSecretCommand command);
}