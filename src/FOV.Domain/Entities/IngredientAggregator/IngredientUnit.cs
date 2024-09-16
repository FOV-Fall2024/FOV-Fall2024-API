using FOV.Domain.Common;

namespace FOV.Domain.Entities.IngredientAggregator;
public class IngredientUnit : BaseAuditableEntity
{
    public Guid IngredientId { get; set; }

    public Ingredient? Ingredient { get; set; }

    public string UnitName { get; set; } = string.Empty;

    public decimal ConversionFactor { get; set; }

    public Guid  IngredientUnitParentId { get; set; }

    public IngredientUnit? IngredientUnitParent { get; set; }

    public virtual ICollection<IngredientUnit> ChildUnits { get; set; } = [];
}
