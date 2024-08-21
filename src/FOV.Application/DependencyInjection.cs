using System.Reflection;
using FluentValidation;
using FOV.Application.Common.Behaviours.Claim;
using Microsoft.Extensions.DependencyInjection;


namespace FOV.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDI(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IClaimService, ClaimService>();
        return services;
    }
}
