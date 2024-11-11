using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.IngredientSupplyRequestAggregator;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.UserAggregator;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Data.Configurations;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);


    DbSet<Restaurant> Restaurants { get; }
    DbSet<Ingredient> Ingredients { get; }

    DbSet<Category> Categories { get; }
    DbSet<IngredientType> IngredientTypes { get; }

    DbSet<IngredientUnit> IngredientUnits { get; }

    DbSet<IngredientGeneral> IngredientGenerals { get; }

    DbSet<DishIngredientGeneral> DishIngredientGenerals { get; }

    DbSet<DishGeneral> DishGenerals { get; }

    DbSet<DishIngredient> DishIngredients { get; }

    DbSet<Dish> Dishes { get; }

    DbSet<Customer> Customers { get; }


    DbSet<IngredientUsage> IngredientTransactions { get; }

    DbSet<Combo> Combos { get; }

    DbSet<DishCombo> DishCombos { get; }


    DbSet<RefundDishInventory> RefundDishInventories { get; }

    DbSet<RefundDishInventoryTransaction> RefundDishInventoryTransactions { get; }

    DbSet<IngredientSupplyRequest> IngredientSupplyRequests { get; }

    DbSet<IngredientSupplyRequestDetail> IngredientSupplyRequestDetails { get; }

    DbSet<DishGeneralImage> DishGeneralImages { get; }
    DbSet<IngredientMeasure> IngredientMeasures { get; }

}
