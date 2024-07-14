using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Data.Configurations;
using FOV.Infrastructure.Repository.IRepositories;
using FOV.Infrastructure.Repository.Repositories;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, string ConnectionString)
    {
        //services.AddOutputCache();
        //services.AddDbContextPool<FOVContext>(options => options.UseNpgsql(ConnectionString));
        //services.AddScoped<ApplicationDbContextInitializer>();
        //services.AddSingleton(TimeProvider.System);
        //services.AddDataProtection();
        services.AddScoped<IIngredientTypeRepository, IngredientTypeRepository>();
        services.AddScoped<IUnitOfWorks, UnitOfWorks>();
        return services;

    }
}
