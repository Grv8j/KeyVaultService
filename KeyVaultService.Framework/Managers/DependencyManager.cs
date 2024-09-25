using System.Reflection;
using KeyVaultService.Framework.Dependency;
using Microsoft.Extensions.DependencyInjection;

namespace KeyVaultService.Framework.Managers;

/// <summary>
/// Dependency manager
/// </summary>
public static class DependencyManager
{
    /// <summary>
    /// Register services from all assemblies in application domain
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection RegisterServicesFromFullScope(this IServiceCollection services)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var type in assembly.GetTypes()
                         .Where(x => 
                             x.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(RegisterServiceAttribute))))
            {
                var attribute = type.GetCustomAttribute<RegisterServiceAttribute>();

                if (attribute?.ServiceInterfaceType.IsAssignableFrom(type) ?? false)
                {
                    services.RegisterServiceByLifetime(attribute.ServiceLifetime, attribute.ServiceInterfaceType, type);
                }
            }
        }

        return services;
    }

    /// <summary>
    /// Registers services into <see cref="IServiceCollection"/> by its lifetime
    /// </summary>
    /// <param name="serviceCollection"><see cref="IServiceCollection"/></param>
    /// <param name="serviceLifetime"><see cref="EServiceLifetime"/></param>
    /// <param name="serviceType">Type of the service</param>
    /// <param name="serviceInterface">Type of the service interface</param>
    /// <returns><see cref="IServiceCollection"/></returns>
    /// <exception cref="ArgumentOutOfRangeException">Exception when unsupported service lifetime is present</exception>
    private static IServiceCollection RegisterServiceByLifetime(
        this IServiceCollection serviceCollection, EServiceLifetime serviceLifetime, Type serviceType, Type serviceInterface)
    {
        return serviceLifetime switch
        {
            EServiceLifetime.Scoped => serviceCollection.AddScoped(serviceInterface, serviceType),
            EServiceLifetime.Transient => serviceCollection.AddTransient(serviceInterface, serviceType),
            EServiceLifetime.Singleton => serviceCollection.AddSingleton(serviceInterface, serviceType),
            _ => throw new ArgumentOutOfRangeException(nameof(serviceLifetime), serviceLifetime, null)
        };
    }
}