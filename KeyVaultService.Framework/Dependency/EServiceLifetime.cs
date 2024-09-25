namespace KeyVaultService.Framework.Dependency;

/// <summary>
/// Service lifetimes enumeration
/// </summary>
public enum EServiceLifetime
{
    /// <summary>
    /// Transient lifetime
    /// </summary>
    Transient,
    
    /// <summary>
    /// Scoped lifetime
    /// </summary>
    Scoped,
    
    /// <summary>
    /// Singleton lifetime
    /// </summary>
    Singleton
}