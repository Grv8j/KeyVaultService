using KeyVaultService.Framework.Dependency;
using KeyVaultService.Persistence.Entities.Interfaces;
using KeyVaultService.Persistence.UnitOfWork;

namespace KeyVaultService.Persistence.AccessManager;

/// <summary>
/// Vault persistence access manager
/// </summary>
/// <param name="unitOfWork">Unit of work</param>
[RegisterService(typeof(IVaultPersistenceAccessManager), EServiceLifetime.Transient)]
internal class VaultPersistenceAccessManager(IUnitOfWorkWritable unitOfWork) : IVaultPersistenceAccessManager
{
    /// <inheritdoc cref="IVaultPersistenceAccessManager.ExecuteReader{TEntity}(System.Func{KeyVaultService.Persistence.UnitOfWork.IUnitOfWork,TEntity})"/>
    public TEntity ExecuteReader<TEntity>(Func<IUnitOfWork, TEntity> query)
        => query(unitOfWork);

    /// <inheritdoc cref="IVaultPersistenceAccessManager.ExecuteWriter{TEntity}"/>
    public TEntity ExecuteWriter<TEntity>(Func<IUnitOfWorkWritable, TEntity> command)
        where TEntity : class, IEntity
        => command(unitOfWork);
}