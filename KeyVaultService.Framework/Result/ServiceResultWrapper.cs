namespace KeyVaultService.Framework.Result;

/// <summary>
/// Service result wrapper
/// </summary>
/// <typeparam name="TResult">Type of result</typeparam>
public class ServiceResultWrapper<TResult> : IServiceResultWrapper<TResult>
    where TResult : class
{
    /// <inheritdoc cref="IServiceResultWrapper{TResult}.Result"/>
    public TResult? Result { get; init; }
    
    /// <inheritdoc cref="IServiceResultWrapper{TResult}.Errors"/>
    public ICollection<string> Errors { get; init; } = new List<string>();
}