using System.Reflection;
using FOV.Domain.Entities.AttendanceAggregator;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.IngredientSupplyRequestAggregator;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.PaymentAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.ShiftAggregator;
using FOV.Domain.Entities.TableAggregator;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using FOV.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Data;

public class FOVContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IApplicationDbContext
{
    public FOVContext(DbContextOptions<FOVContext> options) : base(options)
    {

    }

    public DbSet<Ingredient> Ingredients => Set<Ingredient>();

    public DbSet<IngredientType> IngredientTypes => Set<IngredientType>();

    public DbSet<IngredientGeneral> IngredientGenerals => Set<IngredientGeneral>();

    public DbSet<DishIngredientGeneral> DishIngredientGenerals => Set<DishIngredientGeneral>();

    public DbSet<DishGeneral> DishGenerals => Set<DishGeneral>();

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<DishIngredient> DishIngredients => Set<DishIngredient>();

    public DbSet<Dish> Dishes => Set<Dish>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<Domain.Entities.OrderAggregator.Order> Orders => Set<Domain.Entities.OrderAggregator.Order>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
    public DbSet<DishCombo> DishCombos => Set<DishCombo>();
    public DbSet<Table> Tables => Set<Table>();

    public DbSet<Customer> Customers => Set<Customer>();


    public DbSet<IngredientTransaction> IngredientTransactions => Set<IngredientTransaction>();

    public DbSet<Combo> Combos => Set<Combo>();
    public DbSet<Shift> Shifts => Set<Shift>();
    public DbSet<WaiterSchedule> WaiterSchedules => Set<WaiterSchedule>();

 

    public DbSet<Restaurant> Restaurants => Set<Restaurant>();

    public DbSet<Payments> Payments => Set<Payments>();
    public DbSet<Rating> Ratings => Set<Rating>();


    public DbSet<IngredientUnit> IngredientUnits => Set<IngredientUnit>();

    public DbSet<RefundDishInventory> RefundDishInventories => Set<RefundDishInventory>();

    public DbSet<RefundDishInventoryTransaction> RefundDishInventoryTransactions => Set<RefundDishInventoryTransaction>();

    public DbSet<DishGeneralImage> DishGeneralImages => Set<DishGeneralImage>();

    public DbSet<IngredientSupplyRequest> IngredientSupplyRequests => Set<IngredientSupplyRequest>();

    public DbSet<IngredientSupplyRequestDetail> IngredientSupplyRequestDetails => Set<IngredientSupplyRequestDetail>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //    builder.Entity<Payments>()
        //.Property(p => p.VnpTxnRef)
        //.HasColumnType("varchar(max)"); // or "text"

    }
}
