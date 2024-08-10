using System.Reflection;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<IngredientTransaction> IngredientTransactions => Set<IngredientTransaction>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
