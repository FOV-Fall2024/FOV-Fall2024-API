using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator.Enums;
using FOV.Domain.Entities.RestaurantAggregator;


namespace FOV.Domain.Entities.IngredientAggregator;

public class Ingredient : BaseAuditableEntity
{

    public Guid IngredientGeneralId { get; set; }

    public IngredientGeneral IngredientGeneral { get; set; }
    public decimal IngredientAmount { get; set; }
    public decimal ExpiredQuantity { get; set; }
    public IngredientType? IngredientType { get; set; }
    public Guid? IngredientTypeId { get; set; }
    public Restaurant? Restaurant { get; set; }
    public Guid? RestaurantId { get; set; }
    public Guid? IngredientMeasureId { get; set; }
    public IngredientMeasure IngredientMeasure { get; set; }
    public virtual ICollection<IngredientUsage> IngredientTransactions { get; set; } = [];
    public virtual ICollection<IngredientUnit> IngredientUnits { get; set; } = [];
    public Ingredient()
    {

    }

    public Ingredient(string name, Guid ingredientTypeId, Guid restaurantId, Guid ingredientGeneralId, Guid? ingredientMeasureId)
    {
        RestaurantId = restaurantId;
        IngredientTypeId = ingredientTypeId;
        IngredientGeneralId = ingredientGeneralId;
        IngredientMeasureId = ingredientMeasureId;
    }

    public void AddQuantity(decimal quantity) => IngredientAmount += quantity;

    public void UpdateExpriedQuantity(decimal quantity)
    {
        ExpiredQuantity += quantity;
        IngredientAmount -= quantity;
        if (ExpiredQuantity < 0) ExpiredQuantity = 0;
    }
}

