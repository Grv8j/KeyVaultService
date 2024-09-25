using KeyVaultService.Framework.Result;
using Microsoft.AspNetCore.Mvc;

namespace KeyVaultService.Controllers;

/// <summary>
/// API Controller for Vault
/// </summary>
public sealed class VaultController : BaseController
{
    /// <summary>
    /// Checks vault name availability
    /// </summary>
    /// <returns>True if available, otherwise false</returns>
    [HttpGet("CheckNameAvailability")]
    [ProducesResponseType(typeof(IServiceResultWrapper<bool>), StatusCodes.Status200OK)]
    public IActionResult CheckNameAvailability()
    {
        return null;
    }
    
    //TODO - GET, Create, List, Purge,...
}