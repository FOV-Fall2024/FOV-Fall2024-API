using FOV.Domain.Common;
using FOV.Domain.Entities.DishAggregator.Enums;
using FOV.Domain.Entities.IngredientAggregator;

namespace FOV.Domain.Entities.DishAggregator;
public class DishIngredient : BaseAuditableEntity
{
    public Dish? Dish { get; set; }

    public Guid DishId { get; set; }

    public decimal Quantity { get; set; }
    public Ingredient? Ingredient { get; set; }

    public Guid IngredientId { get; set; }

    public DishIngredientStatus DishIngredientStatus { get; set; }

    public DishIngredient()
    {

    }

    public DishIngredient(Guid dishId, Guid ingredientId, decimal quantity)
    {
        IngredientId = ingredientId;
        DishId = dishId;
        Quantity = quantity;
        DishIngredientStatus = DishIngredientStatus.Normal;

    }

    public DishIngredient(Guid dishId, Guid ingredientId, decimal quantity,DishIngredientStatus type)
    {
        IngredientId = ingredientId;
        DishId = dishId;
        Quantity = quantity;
        DishIngredientStatus = type;
    }

    public void ChangeState(DishIngredientStatus status) => DishIngredientStatus = status;
}
