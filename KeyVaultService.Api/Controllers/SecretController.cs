using KeyVaultService.Framework.Result;
using KeyVaultService.Interface;
using KeyVaultService.Interface.Command;
using KeyVaultService.Interface.Models;
using KeyVaultService.Interface.Query;
using KeyVaultService.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeyVaultService.Controllers;

/// <summary>
/// API Controller for Key part of key vault
/// </summary>
public sealed class SecretController : BaseController
{
    private readonly IVaultSecretsQueryService vaultSecretsQueryService;
    private readonly IVaultSecretsCommandService vaultSecretsCommandService;

    /// <summary>
    /// C-tor
    /// </summary>
    /// <param name="vaultSecretsQueryService">Vault secrets query service</param>
    /// <param name="vaultSecretsCommandService">Vault secrets command service</param>
    public SecretController(
        IVaultSecretsQueryService vaultSecretsQueryService,
        IVaultSecretsCommandService vaultSecretsCommandService)
    {
        this.vaultSecretsQueryService = vaultSecretsQueryService;
        this.vaultSecretsCommandService = vaultSecretsCommandService;
    }

    /// <summary>
    /// Gets vault secrets
    /// </summary>
    /// <param name="vaultId">Id of the vault</param>
    /// <returns><inheritdoc cref="VmVaultSecrets"/></returns>
    [HttpGet("GetKeys")]
    [ProducesResponseType(typeof(IServiceResultWrapper<VmVaultSecrets>), StatusCodes.Status200OK)]
    public IServiceResultWrapper<VmVaultSecrets> GetVaultSecrets(Guid vaultId)
    {
        return vaultSecretsQueryService.GetSecretsForVault(new VmGetVaultSecretsByIdQuery
        {
            VaultId = vaultId
        });
    }

    /// <summary>
    /// Creates new secret in the vault
    /// </summary>
    /// <param name="command"><inheritdoc cref="VmCreateSecretCommand"/></param>
    /// <returns>Id of created secret</returns>
    [HttpPost(nameof(CreateSecret))]
    [ProducesResponseType(typeof(IServiceResultWrapper<VmIdentifier>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IServiceResultWrapper<>), StatusCodes.Status400BadRequest)]
    public IServiceResultWrapper<VmBase> CreateSecret(VmCreateSecretCommand command) 
        => vaultSecretsCommandService.CreateSecret(command);
}