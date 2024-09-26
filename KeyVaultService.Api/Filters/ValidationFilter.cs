using KeyVaultService.Framework.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KeyVaultService.Filters;
/// <summary>
/// Validation filter to enable validation in filter pipeline
/// </summary>
public class ValidationFilter : IActionFilter
{
    /// <inheritdoc cref="IActionFilter.OnActionExecuting"/>
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var messages = context.ModelState
                .SelectMany(message => message.Value.Errors)
                .Select(error => error.ErrorMessage)
                .ToList();
           
            context.Result = new BadRequestObjectResult(
                ServiceResultWrapperProvider.CreateErrorOnlyWrapper(messages));
        }
    }

    /// <inheritdoc cref="IActionFilter.OnActionExecuted"/>
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}