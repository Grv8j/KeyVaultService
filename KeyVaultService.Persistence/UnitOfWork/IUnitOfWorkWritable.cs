namespace KeyVaultService.Persistence.UnitOfWork;

/// <summary>
/// Unit of work writable interface
/// </summary>
public interface IUnitOfWorkWritable : IUnitOfWork
{
    /// <summary>
    /// Saves changes on write operations to database
    /// </summary>
    void SaveChanges();
}