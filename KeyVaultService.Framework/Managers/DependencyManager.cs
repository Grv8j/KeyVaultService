using System.Reflection;
using KeyVaultService.Framework.Dependency;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

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
        var assemblyDict = new Dictionary<string, Assembly>();
        foreach (var assemblyName in DependencyContext.Default?.GetDefaultAssemblyNames() ?? [])
        {
            RegisterService(Assembly.Load(assemblyName), services, assemblyDict);
        }

        return services;
    }

    /// <summary>
    /// Register services from specified assembly
    /// </summary>
    /// <param name="assembly">Loaded assembly</param>
    /// <param name="services">Collection of services</param>
    /// <param name="assemblyDict">Already loaded assemblies dictionary</param>
    /// <returns><inheritdoc cref="IServiceCollection"/></returns>
    private static IServiceCollection RegisterService(Assembly assembly, IServiceCollection services, IDictionary<string, Assembly> assemblyDict)
    {
        if (assembly.FullName == null || assemblyDict.ContainsKey(assembly.FullName))
        {
            return services;
        }
        
        foreach (var type in assembly.GetTypes()
                     .Where(x => 
                         x.GetCustomAttributes(typeof(RegisterServiceAttribute)).Any() || (typeof(IMapper).IsAssignableFrom(x) && x.IsClass)))
        {
            //If type is of mapper type, register map also
            if (typeof(IMapper).IsAssignableFrom(type))
            {
                var mapper = Activator.CreateInstance(type) as IMapper;
                mapper?.Map();
            }
            
            var attribute = type.GetCustomAttribute<RegisterServiceAttribute>();

            if (attribute != null && (attribute.ServiceInterfaceType.IsAssignableFrom(type) || type.IsGenericTypeDefinition))
            {
                services.RegisterServiceByLifetime(attribute.ServiceLifetime, type, attribute.ServiceInterfaceType);
            }
        }
        
        assemblyDict.Add(assembly.FullName, assembly);

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