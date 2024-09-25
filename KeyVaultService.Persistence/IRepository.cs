using System.Linq.Expressions;

namespace KeyVaultService.Persistence;

/// <summary>
/// Repository interface
/// </summary>
/// <typeparam name="T">Type of entity</typeparam>
public interface IRepository<T> : IDisposable
    where T : class
{
    /// <summary>
    /// Gets queryable of the entity
    /// </summary>
    /// <returns><see cref="IQueryable{T}"/> of entity </returns>
    IQueryable<T> GetQueryable();
    
    /// <summary>
    /// Adds new entity into db set
    /// </summary>
    /// <param name="entity">Entity of type <see cref="T"/> to add </param>
    void Add(T entity);
    
    /// <summary>
    /// Adds new entity into db set
    /// </summary>
    /// <param name="entities">Collection of entities of type <see cref="T"/> to add </param>
    void AddRange(IEnumerable<T> entities);
    
    /// <summary>
    /// Removes specified entity from db set
    /// </summary>
    /// <param name="entity">Entity to remove of type <see cref="T"/></param>
    void Remove(T entity);
    
    /// <summary>
    /// Removes entity from db set by specified predicate
    /// </summary>
    /// <param name="predicate">Remove predicate</param>
    void RemoveWhere(Expression<Func<T, bool>> predicate);
    
    /// <summary>
    /// Gets collection of entities of type <see cref="T"/> which satisfied predicate
    /// </summary>
    /// <param name="predicate">Get predicate</param>
    IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Saves changes to database
    /// </summary>
    /// <returns>Number of affected entities</returns>
    int Save();
}
