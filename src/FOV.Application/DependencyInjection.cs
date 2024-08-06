using System.Reflection;
using FluentValidation;
using FOV.Application.Common.Behaviours;
using FOV.Application.Common.Behaviours.Claim;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace FOV.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDI(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IClaimService, ClaimService>();
        return services;
    }
}
