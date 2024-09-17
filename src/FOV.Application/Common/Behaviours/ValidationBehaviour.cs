using System.Text.Json;
using FluentValidation;
using FOV.Application.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace FOV.Application.Common.Behaviours;

public sealed class ValidationBehavior<TRequest, TResponse>(
    IServiceProvider serviceProvider,
    ILogger<ValidationBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        const string behavior = nameof(ValidationBehavior<TRequest, TResponse>);

        logger.LogInformation(
            "[{Behavior}] handle request={RequestData} and response={ResponseData}",
            behavior, typeof(TRequest).FullName, typeof(TResponse).FullName);

        logger.LogDebug(
            "[{Behavior}] handle request={Request} with content={RequestData}",
            behavior, typeof(TRequest).FullName, JsonSerializer.Serialize(request));

        var validators = serviceProvider
                             .GetService<IEnumerable<IValidator<TRequest>>>()?.ToList()
                         ?? throw new InvalidOperationException();

        if (validators.Count != 0)
            await Task.WhenAll(
                validators.Select(v => v.HandleValidationAsync(request))
            );

        var response = await next();

        return response;
    }
}
public static class Validation
{
    public static async Task HandleValidationAsync<TRequest>(this IValidator<TRequest> validator, TRequest request)
    {
        var validationResult = await validator.ValidateAsync(request);
        var failures = validationResult.Errors;

        if (failures.Any())
        {
            var errorMessages = string.Join(", ", failures.Select(f => f.ErrorMessage));
            throw new AppException(errorMessages);
        }
    }
}

