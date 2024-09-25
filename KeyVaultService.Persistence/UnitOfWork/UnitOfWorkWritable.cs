using KeyVaultService.Framework.Dependency;

namespace KeyVaultService.Persistence.UnitOfWork;

/// <summary>
/// Unit of work writable implementation
/// </summary>
/// <param name="dbContext">Key vault database context</param>
/// <param name="serviceProvider">Service provider</param>
[RegisterService(typeof(IUnitOfWorkWritable), EServiceLifetime.Transient)]
internal class UnitOfWorkWritable
    (KeyVaultDbContext dbContext, IServiceProvider serviceProvider) : UnitOfWork(dbContext, serviceProvider), IUnitOfWorkWritable
{
    /// <inheritdoc cref="IUnitOfWorkWritable.SaveChanges"/>
    public void SaveChanges() => dbContext.SaveChanges();
}