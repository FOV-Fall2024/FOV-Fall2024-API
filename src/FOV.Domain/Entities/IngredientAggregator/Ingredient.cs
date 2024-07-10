using FOV.Domain.Common;


namespace FOV.Domain.Entities.IngredientAggregator;

public class Ingredient : BaseEntity
{
    public string IngredientName { get; set; } = string.Empty;

    public decimal IngredientAmount { get; set;}

    public decimal ExpriedQuantity { get; set;}

    public IngredientType? IngredientType { get; set;} 
    
    public Guid IngredientTypeId { get; set;}

}

