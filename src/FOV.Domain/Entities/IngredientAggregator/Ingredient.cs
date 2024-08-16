using FOV.Domain.Common;
using FOV.Domain.Entities.RestaurantAggregator;


namespace FOV.Domain.Entities.IngredientAggregator;

public class Ingredient : BaseAuditableEntity
{
    public string IngredientName { get; set; } = string.Empty;

    public decimal IngredientAmount { get; set; }

    public decimal ExpriedQuantity { get; set; }

    public IngredientType? IngredientType { get; set; }

    public Guid? IngredientTypeId { get; set; }

    public Restaurant? Restaurant { get; set; }

    public Guid? RestaurantId { get; set; }

    public virtual ICollection<IngredientTransaction> IngredientTransactions { get; set; } = [];

    public Ingredient()
    {

    }

    public Ingredient(string name, Guid ingredientTypeId, Guid restaurantId)
    {
        IngredientName = name;
        RestaurantId = restaurantId;
        IngredientTypeId = ingredientTypeId;
    }

    public void AddQuantity(decimal quantity) => IngredientAmount += quantity;
}

