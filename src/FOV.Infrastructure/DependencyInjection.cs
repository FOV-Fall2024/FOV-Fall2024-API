using FOV.Infrastructure.Caching.CachingService;
using FOV.Infrastructure.Caching.ICachingService;
using FOV.Infrastructure.Data.FluentAPI;
using FOV.Infrastructure.Elastic.IService;
using FOV.Infrastructure.Elastic.Service;
using FOV.Infrastructure.Helpers.FirebaseHandler;
using FOV.Infrastructure.Helpers.QRCodeGeneratorHelper;
using FOV.Infrastructure.Repository.IRepositories;
using FOV.Infrastructure.Repository.Repositories;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace FOV.Infrastructure;
public static class DependencyInjection
{
    public static object AddInfrastructureDI(this IServiceCollection services)
    {

        //? DI with ElasticSearch Db
        //  services.AddSingleton<IElasticService, ElasticService>();
        services.AddSingleton<IUserElasticService, UserElasticService>();



        //? DI with Main Db
        services.AddScoped<IIngredientGeneralRepository, IngredientGeneralRepository>();
        services.AddScoped<IIngredientTypeRepository, IngredientTypeRepository>();
        services.AddScoped<ITableRepository, TableRepository>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IIngredientRepository, IngredientRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductComboRepository, ProductComboRepository>();
        services.AddScoped<IComboRepository, ComboRepository>();
        services.AddScoped<IProductIngredientRepository, ProductIngredientRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IShiftRepository, ShiftRepository>();
        services.AddScoped<IWaiterScheduleRepository, WaiterScheduleRepository>();
        services.AddScoped<IProductGeneralRepository, ProductGeneralRepository>();
        services.AddScoped<IProductIngredientGeneralRepository, ProductIngredientGeneralRepository>();
        services.AddSingleton<StorageHandler>();
        services.AddSingleton<QRCodeGeneratorHandler>();
        services.AddScoped<IUnitOfWorks, UnitOfWorks>();
        //services.AddScoped<ILockingService, LockingService>();
        services.AddScoped<IIngrdientTransactionRepository, IngrdientTransactionRepository>();
        services.AddScoped<IProductImageRepository, ProductImageRepository>();
        services.AddScoped<IRatingRepository, RatingRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IGroupUserRepository, GroupUserRepository>();
        services.AddScoped<IGroupMessageRepository, GroupMessageRepository>();
        services.AddScoped<IGroupChatRepository, GroupChatRepository>();
        return services;

    }
}
