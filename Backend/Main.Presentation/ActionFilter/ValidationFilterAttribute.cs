using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Main.Presentation.ActionFilter;

public class ValidationFilterAttribute : IActionFilter
{
    public ValidationFilterAttribute()
    {
        
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        object? action = context.RouteData.Values["action"];
        object? controller = context.RouteData.Values["controller"];
        object? param = 
            context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;
        if (param is null)
        {
            context.Result =
                new BadRequestObjectResult($"Object is null. Controller: {controller}, Action: {action}");
            return;
        }

        if (!context.ModelState.IsValid)
            context.Result =
                new UnprocessableEntityObjectResult(context.ModelState);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        
    }
}