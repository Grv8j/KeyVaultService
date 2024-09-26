using KeyVaultService.Persistence.Entities.Interfaces;
using KeyVaultService.Persistence.Repository;

namespace KeyVaultService.Persistence.UnitOfWork;

/// <summary>
/// Unit of work
/// </summary>
internal class UnitOfWork : IUnitOfWork
{
    protected readonly KeyVaultDbContext dbContext;

    /// <summary>
    /// C-tor
    /// </summary>
    /// <param name="dbContext">Db context</param>
    protected UnitOfWork(
        KeyVaultDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// <inheritdoc cref="IUnitOfWork.Dispose"/>
    public void Dispose() => dbContext.Dispose();

    /// <inheritdoc cref="IUnitOfWork.GetRepository{TEntity}"/>
    public IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class, IEntity
    {
        return new Repository<TEntity>(dbContext);
    }
}