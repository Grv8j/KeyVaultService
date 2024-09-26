namespace KeyVaultService.Framework.Result;

/// <summary>
/// Service result wrapper provider for creation of wrapper
/// </summary>
public static class ServiceResultWrapperProvider
{
    /// <summary>
    /// Creates new instance of result wrapper
    /// </summary>
    /// <param name="result">Result</param>
    /// <typeparam name="TResult">Type of result, see <inheritdoc cref="TResult"/> </typeparam>
    /// <returns>New instance of <inheritdoc cref="ServiceResultWrapper{TResult}"/> </returns>
    public static IServiceResultWrapper<TResult> CreateWrapper<TResult>(TResult result)
        where TResult : class =>
        new ServiceResultWrapper<TResult>
        {
            Result = result
        };
    
    /// <summary>
    /// Creates new instance of result wrapper with errors only
    /// </summary>
    /// <param name="errors">Collection of errors</param>
    /// <returns>New instance of <inheritdoc cref="ServiceResultWrapper{TResult}"/> </returns>
    public static IServiceResultWrapper<object> CreateErrorOnlyWrapper(ICollection<string> errors)
        => new ServiceResultWrapper<object>
        {
            Errors = errors
        };
}