using KeyVaultService.Framework.Dependency;
using KeyVaultService.Persistence.Entities.Interfaces;
using KeyVaultService.Persistence.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace KeyVaultService.Persistence.AccessManager;

/// <summary>
/// Vault persistence access manager
/// </summary>
/// <param name="serviceScopeFactory">Service scope factory</param>
[RegisterService(typeof(IVaultPersistenceAccessManager), EServiceLifetime.Transient)]
internal class VaultPersistenceAccessManager(IServiceScopeFactory serviceScopeFactory) : IVaultPersistenceAccessManager
{
    /// <inheritdoc cref="IVaultPersistenceAccessManager.ExecuteReader{TEntity}(System.Func{KeyVaultService.Persistence.UnitOfWork.IUnitOfWork,TEntity})"/>
    public TEntity ExecuteReader<TEntity>(Func<IUnitOfWork, TEntity> query)
        => PerformScopedDbAction(query);

    /// <inheritdoc cref="IVaultPersistenceAccessManager.ExecuteWriter{TEntity}"/>
    public TEntity ExecuteWriter<TEntity>(Func<IUnitOfWorkWritable, TEntity> command)
        where TEntity : class, IEntity
        => PerformScopedDbAction(command, true);

    /// <summary>
    /// Performs scoped action on database
    /// In case of write operation creates a transaction
    /// </summary>
    /// <param name="action">Action</param>
    /// <param name="isWriter">Flag if operation is write or not</param>
    /// <typeparam name="TEntity">Type of database entity</typeparam>
    /// <returns><inheritdoc cref="TEntity"/></returns>
    private TEntity PerformScopedDbAction<TEntity>(Func<IUnitOfWorkWritable, TEntity> action, bool isWriter = false)
    {
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<KeyVaultDbContext>();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWorkWritable>();

            if (!isWriter)
            {
                return action(unitOfWork);
            }
            
            context.Database.BeginTransaction();
            var result = action(unitOfWork);
            context.Database.CommitTransaction();
                
            return result;
        }
    }
}