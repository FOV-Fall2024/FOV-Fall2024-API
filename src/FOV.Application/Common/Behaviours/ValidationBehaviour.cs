using System.Text.Json;
using FluentValidation;
using FOV.Application.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace FOV.Application.Common.Behaviours;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

    public ValidationBehavior(
        IServiceProvider serviceProvider,
        ILogger<ValidationBehavior<TRequest, TResponse>> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        const string behavior = nameof(ValidationBehavior<TRequest, TResponse>);

        _logger.LogInformation(
            "[{Behavior}] handle request={RequestType} and response={ResponseType}",
            behavior, typeof(TRequest).FullName, typeof(TResponse).FullName);

        _logger.LogDebug(
            "[{Behavior}] handle request={RequestType} with content={RequestData}",
            behavior, typeof(TRequest).FullName, JsonSerializer.Serialize(request));

        var validators = _serviceProvider
            .GetService<IEnumerable<IValidator<TRequest>>>()
            ?.ToList() ?? new List<IValidator<TRequest>>();

        var allFieldErrors = new List<FieldError>();

        foreach (var validator in validators)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    allFieldErrors.Add(new FieldError
                    {
                        Field = char.ToLowerInvariant(item.PropertyName[0]) + item.PropertyName.Substring(1),
                        Message = item.ErrorMessage
                    });
                }
            }
        }

        if (allFieldErrors.Any())
        {
            throw new AppException("Validation errors occurred", allFieldErrors);
        }

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

