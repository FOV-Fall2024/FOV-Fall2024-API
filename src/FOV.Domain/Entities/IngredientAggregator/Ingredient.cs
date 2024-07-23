using FOV.Domain.Common;
using FOV.Domain.Entities.RestaurantAggregator;


namespace FOV.Domain.Entities.IngredientAggregator;

public class Ingredient : BaseEntity
{
    public string IngredientName { get; set; } = string.Empty;

    public decimal IngredientAmount { get; set; }

    public decimal ExpriedQuantity { get; set; }

    public IngredientType? IngredientType { get; set; }

    public Guid? IngredientTypeId { get; set; }

    public Restaurant? Restaurant { get; set; }

    public Guid? RestaurantId { get; set; }

}

