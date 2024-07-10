using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FOV.Infrastructure.Data;

public class FOVContext : IdentityDbContext<User>, IApplicationDbContext
{
    public FOVContext(DbContextOptions<FOVContext> options) : base(options)
    {

    }

    public DbSet<Ingredient> Ingredients => Set<Ingredient>();

    public DbSet<IngredientType> IngredientTypes => Set<IngredientType>();

    public DbSet<IngredientGeneral> IngredientGenerals => Set<IngredientGeneral>();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
