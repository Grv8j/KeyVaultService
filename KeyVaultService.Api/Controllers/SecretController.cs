using KeyVaultService.Framework.Result;
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

    /// <summary>
    /// C-tor
    /// </summary>
    /// <param name="vaultSecretsQueryService">Vault secrets query service</param>
    public SecretController(IVaultSecretsQueryService vaultSecretsQueryService)
    {
        this.vaultSecretsQueryService = vaultSecretsQueryService;
    }

    /// <summary>
    /// Gets vault secrets
    /// </summary>
    /// <param name="vaultId">Id of the vault</param>
    /// <returns><inheritdoc cref="VmVaultSecrets"/></returns>
    [HttpGet(nameof(GetVaultSecrets))]
    [ProducesResponseType(typeof(IServiceResultWrapper<VmVaultSecrets>), StatusCodes.Status200OK)]
    public IServiceResultWrapper<VmVaultSecrets> GetVaultSecrets(Guid vaultId)
    {
        return vaultSecretsQueryService.GetSecretsForVault(new VmGetVaultSecretsByIdQuery
        {
            VaultId = vaultId
        });
    }
}