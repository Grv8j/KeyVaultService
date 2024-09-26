namespace KeyVaultService.Interface;

/// <summary>
/// Base view model with identifier
/// </summary>
public class VmIdentifier : VmBase
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
}