using FOV.Application.Common.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace FOV.Presentation.Infrastructure.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (AppException ex)
        {
            await HandleAppExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleAppExceptionAsync(HttpContext context, AppException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var result = JsonConvert.SerializeObject(new
        {
            message = exception.Message,
            errors = exception.FieldErrors // Include the detailed errors here
        });

        return context.Response.WriteAsync(result);
    }
}

