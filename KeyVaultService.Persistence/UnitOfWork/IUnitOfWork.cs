using KeyVaultService.Persistence.Entities.Interfaces;
using KeyVaultService.Persistence.Repository;

namespace KeyVaultService.Persistence.UnitOfWork;

/// <summary>
/// Unit of work interface
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Gets repository for specified entity of type <see cref="TEntity"/>
    /// </summary>
    /// <typeparam name="TEntity">Type of database entity</typeparam>
    /// <returns>Repository for entity</returns>
    IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class, IEntity;
}