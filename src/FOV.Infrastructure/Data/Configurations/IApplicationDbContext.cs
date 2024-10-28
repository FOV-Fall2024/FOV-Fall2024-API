using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.UserAggregator;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Data.Configurations;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);


    DbSet<Rating> Ratings { get; }
    DbSet<Restaurant> Restaurants { get; }
    DbSet<Ingredient> Ingredients { get; }

    DbSet<Category> Categories { get; }
    DbSet<IngredientType> IngredientTypes { get; }

    DbSet<IngredientUnit> IngredientUnits { get; }

    DbSet<IngredientGeneral> IngredientGenerals { get; }

    DbSet<DishIngredientGeneral> DishIngredientGenerals { get; }

    DbSet<IngredientTransaction> IngredientTransactions { get; }
    DbSet<DishGeneral> DishGenerals { get; }

    DbSet<DishIngredient> DishIngredients { get; }

    DbSet<Dish> Dishes { get; }
    DbSet<IngredientRequest> IngredientRequests { get; }

    DbSet<IngredientRequestDetail> IngredientRequestDetails { get; }
    DbSet<Combo> Combos { get; }

    DbSet<DishCombo> DishCombos { get; }
    DbSet<RefundDishInventory> RefundDishInventories { get; }

    DbSet<RefundDishInventoryTransaction> RefundDishInventoryTransactions { get; }


    DbSet<DishGeneralImage> DishGeneralImages { get; }


}
