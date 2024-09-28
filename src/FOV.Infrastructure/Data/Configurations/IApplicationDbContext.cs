using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.GroupChatAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.NewDishRecommendAggregator;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.UserAggregator;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Data.Configurations;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    DbSet<DishImage> DishImages { get; }

    DbSet<Rating> Ratings { get; }
    DbSet<Restaurant> Restaurants { get; }
    DbSet<Ingredient> Ingredients { get; }

    DbSet<Category> Categories { get; }
    DbSet<IngredientType> IngredientTypes { get; }

    DbSet<IngredientGeneral> IngredientGenerals { get; }

    DbSet<DishIngredientGeneral> DishIngredientGenerals { get; }

    DbSet<DishGeneral> DishGenerals { get; }

    DbSet<DishIngredient> DishIngredients { get; }

    DbSet<Dish> Dishes { get; }

    DbSet<Customer> Customers { get; }

    DbSet<Employee> Employees { get; }

    DbSet<IngredientTransaction> IngredientTransactions { get; }

    DbSet<Combo> Combos { get; }

    DbSet<DishCombo> ProductCombos { get; }

    DbSet<GroupChat> GroupChats { get; }

    DbSet<GroupUser> GroupUsers { get; }

    DbSet<GroupMessage> GroupMessages { get; }


    DbSet<NewDishRecommend> NewDishRecommends { get; }

    DbSet<NewDishRecommendLog> NewDishRecommendLogs { get; }

}
