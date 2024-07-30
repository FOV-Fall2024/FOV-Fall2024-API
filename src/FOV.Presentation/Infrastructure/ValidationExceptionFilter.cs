using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FOV.Presentation.Infrastructure;

public class ValidationExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ValidationException validationException)
        {
            var errorMessages = validationException.Errors.Select(e => e.ErrorMessage).ToList();
            var errorResponse = new
            {
                Status = 421,
                Errors = errorMessages
            };

            context.Result = new ObjectResult(errorResponse)
            {
                StatusCode = 421
            };
            context.ExceptionHandled = true;
        }
    }
}
