using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KeyVaultService.Persistence;

/// <summary>
/// Extension to register services from persistence layer into <see cref="IServiceCollection"/>
/// </summary>
public static class RegisterPersistenceExtension
{
    /// <summary>
    /// Register services from persistence layer
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <param name="connectionString">Database connection string</param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection RegisterPersistenceLayer(this IServiceCollection services, string? connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString));
        }
        
        return services.AddDbContext<KeyVaultDbContext>(opt =>
            opt.UseSqlServer(connectionString));
    }
}