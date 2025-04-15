
using Microsoft.AspNetCore.Mvc.Filters;
using School_API.App.DTO;
using School_API.Core.Exceptions;

public class ValidateModelAttribute : ActionFilterAttribute
{

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if(!context.ModelState.IsValid) 
        {
            List<ModelStateErrorsDTO> errorsList = context.ModelState
                .Where(ms => ms.Value!.Errors.Any())
                .SelectMany(ms => ms.Value!.Errors.Select( error => new ModelStateErrorsDTO { Field = ms.Key, Error = error.ErrorMessage }))
                .ToList();

            throw new ModelStateException(errorsList);
        }
    }
}