using System.Reflection;
using System.Reflection.Emit;
using FOV.Domain.Entities.AttendanceAggregator;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.GroupChatAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.NewProductRecommendAggregator;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.PaymentAggregator;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.ShiftAggregator;
using FOV.Domain.Entities.TableAggregator;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using FOV.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Elastic.Clients.Elasticsearch.JoinField;

namespace FOV.Infrastructure.Data;

public class FOVContext : IdentityDbContext<User>, IApplicationDbContext
{
    public FOVContext(DbContextOptions<FOVContext> options) : base(options)
    {

    }

    public DbSet<Ingredient> Ingredients => Set<Ingredient>();

    public DbSet<IngredientType> IngredientTypes => Set<IngredientType>();

    public DbSet<IngredientGeneral> IngredientGenerals => Set<IngredientGeneral>();

    public DbSet<ProductIngredientGeneral> ProductIngredientGenerals => Set<ProductIngredientGeneral>();

    public DbSet<ProductGeneral> ProductGenerals => Set<ProductGeneral>();

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<ProductIngredient> ProductIngredients => Set<ProductIngredient>();

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
    public DbSet<ProductCombo> ProductCombos => Set<ProductCombo>();
    public DbSet<Table> Tables => Set<Table>();

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<IngredientTransaction> IngredientTransactions => Set<IngredientTransaction>();

    public DbSet<Combo> Combos => Set<Combo>();
    public DbSet<Shift> Shifts => Set<Shift>();
    public DbSet<WaiterSchedule> WaiterSchedules => Set<WaiterSchedule>();

    public DbSet<GroupChat> GroupChats => Set<GroupChat>();

    public DbSet<GroupUser> GroupUsers => Set<GroupUser>();

    public DbSet<GroupMessage> GroupMessages => Set<GroupMessage>();

    public DbSet<Restaurant> Restaurants => Set<Restaurant>();

    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<Payments> Payments => Set<Payments>();
    public DbSet<Rating> Ratings => Set<Rating>();

    public DbSet<NewProductRecommend> NewProductRecommends => Set<NewProductRecommend>();

    public DbSet<NewProductRecommendLog> NewProductRecommendLogs => Set<NewProductRecommendLog>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    //    builder.Entity<Payments>()
    //.Property(p => p.VnpTxnRef)
    //.HasColumnType("varchar(max)"); // or "text"

    }
}
