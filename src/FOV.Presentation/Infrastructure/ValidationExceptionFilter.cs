using FluentValidation;
using FOV.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FOV.Presentation.Infrastructure;

public class ValidationExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ValidationException validationException)
        {
            throw new AppException(validationException.Errors.Select(e => e.ErrorMessage).ToList());
        }
    }
}
