using KeyVaultService.Persistence.Entities.Interfaces;
using KeyVaultService.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace KeyVaultService.Persistence.UnitOfWork;

/// <summary>
/// Unit of work
/// </summary>
internal class UnitOfWork : IUnitOfWork
{
    protected readonly KeyVaultDbContext dbContext;
    private readonly IServiceProvider serviceProvider;

    /// <summary>
    /// C-tor
    /// </summary>
    /// <param name="dbContext">Db context</param>
    /// <param name="serviceProvider">Service provider</param>
    protected UnitOfWork(
        KeyVaultDbContext dbContext,
        IServiceProvider serviceProvider)
    {
        this.dbContext = dbContext;
        this.serviceProvider = serviceProvider;
    }

    /// <inheritdoc cref="IUnitOfWork.Dispose"/>
    public void Dispose() => dbContext.Dispose();

    /// <inheritdoc cref="IUnitOfWork.GetRepository{TEntity}"/>
    public IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class, IEntity
    {
        // return serviceProvider.GetService<IRepository<TEntity>>()
        //        ?? throw new InvalidOperationException($"Repository is not registered for type {typeof(IRepository<TEntity>).FullName}");

        return new Repository<TEntity>(dbContext);
    }
}