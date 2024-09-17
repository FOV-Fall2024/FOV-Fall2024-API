using FOV.Domain.Common;

namespace FOV.Domain.Entities.IngredientAggregator;
public class IngredientUnit : BaseAuditableEntity
{
    public Guid IngredientId { get; set; }

    public Ingredient? Ingredient { get; set; }

    public string UnitName { get; set; } = string.Empty;

    public decimal ConversionFactor { get; set; }

    public Guid? IngredientUnitParentId { get; set; } = Guid.Empty;

    public IngredientUnit? IngredientUnitParent { get; set; }

    public virtual ICollection<IngredientUnit> ChildUnits { get; set; } = [];

    public IngredientUnit()
    {

    }

    // Default Unit 
    public IngredientUnit(string measure, Guid ingredientId)
    {
        UnitName = measure;
        ConversionFactor = 1;
        IngredientId = ingredientId;

    }

    // Child Unit

    public IngredientUnit(string measure, Guid ingredientId, Guid ingredientUnitParentId, decimal conversionFactor)
    {
        UnitName = measure;
        ConversionFactor = conversionFactor;
        IngredientId = ingredientId;
        IngredientUnitParentId = ingredientUnitParentId;
    }
}
