namespace KeyVaultService.Framework.Dependency;

/// <summary>
/// Class decoration attribute responsible for registering services into DI container
/// </summary>
/// <param name="serviceType">Type of the service interface</param>
/// <param name="serviceLifetime">Service lifetime enumeration value</param>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class RegisterServiceAttribute(
    Type serviceType,
    EServiceLifetime serviceLifetime = EServiceLifetime.Transient) : Attribute
{
    public Type ServiceInterfaceType { get; } = serviceType;
    public EServiceLifetime ServiceLifetime { get; } = serviceLifetime;
}