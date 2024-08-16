using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Domain.Entities.UserAggregator;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Data.Configurations;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    DbSet<Ingredient> Ingredients { get; }

    DbSet<Category> Categories { get; }
    DbSet<IngredientType> IngredientTypes { get; }

    DbSet<IngredientGeneral> IngredientGenerals { get; }

    DbSet<ProductIngredientGeneral> ProductIngredientGenerals { get; }

    DbSet<ProductGeneral> ProductGenerals { get; }

    DbSet<ProductIngredient> ProductIngredients { get; }

    DbSet<Product> Products { get; }

    DbSet<Customer> Customers { get; }

    DbSet<Employee> Employees { get; }

    DbSet<IngredientTransaction> IngredientTransactions { get; }

    DbSet<Combo> Combos { get; }

    DbSet<ProductCombo> ProductCombos { get; }
}
