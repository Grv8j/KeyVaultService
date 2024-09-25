using KeyVaultService.Persistence.Entities.Interfaces;

namespace KeyVaultService.Persistence.Entities;

/// <summary>
/// Secret value log entity
/// </summary>
public class SecretValueLog : IEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Created
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Last operation timestamp
    /// </summary>
    public DateTime LastOperationTimestamp { get; set; }

    /// <summary>
    /// Created by
    /// </summary>
    public string CreatedBy { get; set; }

    /// <summary>
    /// Modified by
    /// </summary>
    public string ModifiedBy { get; set; } = null!;

    /// <summary>
    /// Secret id
    /// </summary>
    public Guid SecretId { get; set; }
    
    /// <summary>
    /// Secret navigation edge
    /// </summary>
    public Secret Secret { get; set; }

    /// <summary>
    /// Secret value id
    /// </summary>
    public Guid SecretValueId { get; set; }

    /// <summary>
    /// Secret value navigation edge
    /// </summary>
    public SecretValue SecretValue { get; set; }
}
