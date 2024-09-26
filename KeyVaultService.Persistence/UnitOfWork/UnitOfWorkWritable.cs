using KeyVaultService.Framework.Dependency;

namespace KeyVaultService.Persistence.UnitOfWork;

/// <summary>
/// Unit of work writable implementation
/// </summary>
/// <param name="dbContext">Key vault database context</param>
[RegisterService(typeof(IUnitOfWorkWritable), EServiceLifetime.Transient)]
internal class UnitOfWorkWritable
    (KeyVaultDbContext dbContext) : UnitOfWork(dbContext), IUnitOfWorkWritable
{
    /// <inheritdoc cref="IUnitOfWorkWritable.SaveChanges"/>
    public void SaveChanges() => dbContext.SaveChanges();
}