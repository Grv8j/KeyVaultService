using Microsoft.AspNetCore.Mvc;

namespace KeyVaultService.Controllers;

/// <summary>
/// Base controller implementation
/// </summary>
[Route("[controller]")]
[ApiController]
public abstract class BaseController : ControllerBase;