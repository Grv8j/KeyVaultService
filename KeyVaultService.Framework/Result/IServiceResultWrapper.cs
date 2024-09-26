namespace KeyVaultService.Framework.Result;

/// <summary>
/// Service result wrapper interface
/// </summary>
/// <typeparam name="TResult">Type of result, <inheritdoc cref="TResult"/></typeparam>
public interface IServiceResultWrapper<out TResult>
{
    /// <summary>
    /// <inheritdoc cref="TResult"/>
    /// </summary>
    public TResult? Result { get; }
    
    /// <summary>
    /// Collection of service errors
    /// </summary>
    public ICollection<string> Errors { get; init; }
}