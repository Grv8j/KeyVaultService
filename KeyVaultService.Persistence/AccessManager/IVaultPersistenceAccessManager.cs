using KeyVaultService.Persistence.Entities.Interfaces;
using KeyVaultService.Persistence.UnitOfWork;

namespace KeyVaultService.Persistence.AccessManager;

/// <summary>
/// Vault persistence access manager
/// </summary>
public interface IVaultPersistenceAccessManager
{
    /// <summary>
    /// Executes read operation and returns a single entity
    /// </summary>
    /// <param name="query">Query delegate</param>
    /// <typeparam name="TEntity">Type of database entity</typeparam>
    /// <returns>Entity</returns>
    TEntity ExecuteReader<TEntity>(Func<IUnitOfWork, TEntity> query);
    
    /// <summary>
    /// Executes write operation and returns saved entity
    /// </summary>
    /// <param name="command">Command delegate</param>
    /// <typeparam name="TEntity">Type of database entity</typeparam>
    /// <returns>Saved entity</returns>
    TEntity ExecuteWriter<TEntity>(Func<IUnitOfWorkWritable, TEntity> command)
        where TEntity : class, IEntity;
}