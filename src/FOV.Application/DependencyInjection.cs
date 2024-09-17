using System.Reflection;
using System.Reflection.Metadata;
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
        services.AddValidatorsFromAssemblies([AssemblyReference.Executing]);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>),
                        ServiceLifetime.Scoped);
        });
       // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IClaimService, ClaimService>();
        return services;
    }


}
public static class AssemblyReference
{
    public static readonly Assembly Executing = Assembly.GetExecutingAssembly();
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
