using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gav.Controllers.Filters;

public class ModelStateValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            string errorMessage = string.Join(" | ", errors);
            context.Result = new BadRequestObjectResult(errorMessage);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}