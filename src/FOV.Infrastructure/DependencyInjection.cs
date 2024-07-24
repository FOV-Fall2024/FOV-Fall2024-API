using FOV.Domain.Helpers.FirebaseHandler;
using FOV.Domain.Helpers.QRCodeGeneratorHelper;
using FOV.Infrastructure.Repository.IRepositories;
using FOV.Infrastructure.Repository.Repositories;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using Microsoft.Extensions.DependencyInjection;

namespace FOV.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
    {
        services.AddScoped<IIngredientGeneralRepository, IngredientGeneralRepository>();
        services.AddScoped<IIngredientTypeRepository, IngredientTypeRepository>();
        services.AddScoped<ITableRepository, TableRepository>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        //services.AddScoped<IGenericRepository, GenericRepository>();
        services.AddScoped<IProductGeneralRepository, ProductGeneralRepository>();
        services.AddScoped<IProductIngredientGeneralRepository,  ProductIngredientGeneralRepository>();
        services.AddSingleton<StorageHandler>();
        services.AddSingleton<QRCodeGeneratorHandler>();
        services.AddScoped<IUnitOfWorks, UnitOfWorks>();
        return services;

    }
}
