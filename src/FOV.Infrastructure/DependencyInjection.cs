using FOV.Domain.Helpers.FirebaseHandler;
using FOV.Domain.Helpers.QRCodeGeneratorHelper;
using FOV.Infrastructure.Data.FluentAPI;
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
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IIngredientRepository, IngredientRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductIngredientRepository, ProductIngredientRepository>();
        //services.AddScoped<IGenericRepository, GenericRepository>();
        services.AddScoped<IProductGeneralRepository, ProductGeneralRepository>();
        services.AddScoped<IProductIngredientGeneralRepository, ProductIngredientGeneralRepository>();
        services.AddSingleton<StorageHandler>();
        services.AddSingleton<QRCodeGeneratorHandler>();
        services.AddScoped<IUnitOfWorks, UnitOfWorks>();
        services.AddScoped<IIngrdientTransactionRepository, IngrdientTransactionRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        return services;

    }
}
