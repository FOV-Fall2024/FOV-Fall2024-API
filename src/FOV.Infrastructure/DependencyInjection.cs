using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Caching.CachingService;
using FOV.Infrastructure.Caching.ICachingService;
using FOV.Infrastructure.Data.FluentAPI;
using FOV.Infrastructure.Elastic.IService;
using FOV.Infrastructure.Elastic.Service;
using FOV.Infrastructure.Helpers.FirebaseHandler;
using FOV.Infrastructure.Helpers.QRCodeGeneratorHelper;
using FOV.Infrastructure.Notifications.Web.SignalR.Notification.Setup;
using FOV.Infrastructure.Notifications.Web.SignalR.Order.Setup;
using FOV.Infrastructure.Repository.IRepositories;
using FOV.Infrastructure.Repository.Repositories;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using Microsoft.AspNetCore.Identity;
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
        services.AddScoped<IDishRepository, DishRepository>();
        services.AddScoped<IIngredientRepository, IngredientRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IDishComboRepository, DishComboRepository>();
        services.AddScoped<IComboRepository, ComboRepository>();
        services.AddScoped<IDishIngredientRepository, DishIngredientRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IShiftRepository, ShiftRepository>();
        services.AddScoped<IWaiterScheduleRepository, WaiterScheduleRepository>();
        services.AddScoped<IDishGeneralRepository, DishGeneralRepository>();
        services.AddScoped<IDishIngredientGeneralRepository, DishIngredientGeneralRepository>();
        services.AddSingleton<StorageHandler>();
        services.AddSingleton<QRCodeGeneratorHandler>();
        services.AddScoped<IUnitOfWorks, UnitOfWorks>();
        services.AddScoped<IIngredientSupplyRequestRepository, IngredientSupplyRequestRepository>();
        services.AddScoped<IIngredientSupplyRequestDetailRepository, IngredientSupplyRequestDetailRepository>();
        //services.AddScoped<ILockingService, LockingService>();
        services.AddScoped<IIngrdientTransactionRepository, IngrdientTransactionRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IAttendanceRepository, AttendanceRepository>();
        services.AddScoped<IIngredientUnitRepository, IngredientUnitRepository>();
        services.AddScoped<IRefundDishInventoryRepository, RefundDishInventoryRepository>();
        services.AddScoped<IRefundDishInventoryTransactionRepository, RefundDishInventoryTransactionRepository>();
        services.AddScoped<IDishGeneralImageRepository, DishGeneralImageRepository>();
        services.AddScoped<IIngredientMeasureRepository, IngredientMeasureRepository>();
        services.AddScoped<ISalaryRepository, SalaryRepository>();
        services.AddScoped<IShiftRestaurantRepository, ShiftRestaurantRepository>();
        services.AddScoped<IOrderResponsibilityRepository, OrderResponsibilityRepository>();
        services.AddScoped<IWaiterSalaryRepository, WaiterSalaryRepository>();
        services.AddSingleton<OrderHub>();
        services.AddSingleton<NotificationHub>();
        return services;

    }
}
