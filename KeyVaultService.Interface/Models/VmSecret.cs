using KeyVaultService.Interface.Query;

namespace KeyVaultService.Interface.Models;

/// <summary>
/// Secret view model
/// </summary>
public class VmSecret : VmBase
{
    /// <summary>
    /// Secret id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Secret name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Created by
    /// </summary>
    public string CreatedBy { get; set; }
    
    /// <summary>
    /// Creation date of the secret
    /// </summary>
    public DateTime Created { get; set; }
    
    /// <summary>
    /// Secret values
    /// </summary>
    public ICollection<VmSecretValue> Values { get; set; }
}