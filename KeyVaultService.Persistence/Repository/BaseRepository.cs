using System.Linq.Expressions;

namespace KeyVaultService.Persistence.Repository;

/// <summary>
/// Base repository implementation
/// </summary>
/// <typeparam name="T">Type of database entity</typeparam>
// internal abstract class BaseRepository<T> : IRepository<T>
//     where T : class
// {
//     private readonly KeyVaultDbContext context;
//
//     /// <summary>
//     /// C-tor
//     /// </summary>
//     /// <param name="context">Key vault database context</param>
//     protected BaseRepository(KeyVaultDbContext context)
//     {
//         this.context = context;
//     }
//
//     /// <inheritdoc cref="IRepository{T}.GetQueryable"/>
//     public IQueryable<T> GetQueryable() =>
//         context.Set<T>().AsQueryable();
//
//     /// <inheritdoc cref="IRepository{T}.Add"/>
//     public void Add(T entity)
//     {
//         context.Set<T>().Add(entity);
//     }
//
//     /// <inheritdoc cref="IRepository{T}.AddRange"/>
//     public void AddRange(IEnumerable<T> entities)
//     {
//         context.Set<T>().AddRange(entities);
//     }
//     
//     /// <inheritdoc cref="IRepository{T}.Remove"/>
//     public void Remove(T entity)
//     {
//         context.Set<T>().Remove(entity);
//     }
//
//     /// <inheritdoc cref="IRepository{T}.RemoveWhere"/>
//     public void RemoveWhere(Expression<Func<T, bool>> predicate)
//     {
//         context.Set<T>().RemoveRange(
//             context.Set<T>().Where(predicate));
//     }
//     
//     /// <inheritdoc cref="IRepository{T}.Get"/>
//     public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
//         => context.Set<T>().Where(predicate);
//
//     /// <inheritdoc cref="IRepository{T}.Save"/>
//     public int Save() => context.SaveChanges();
//
//     /// <inheritdoc cref="IRepository{T}.Dispose"/>
//     public void Dispose()
//     {
//         context.Dispose();
//     }
// }