using FOV.Application.Common.Exceptions;

namespace FOV.Presentation.Infrastructure.Middleware;

public class UnauthorizedMiddleware
{
    private readonly RequestDelegate _next;

    public UnauthorizedMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context)
    {
        await _next(context);

        // Check for 401 status code
        if (context.Response.StatusCode == 401)
        {
            // Redirect to login page (or handle response)
            throw new AppException("Unauthorize");
        }
    }
}
