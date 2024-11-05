using FOV.Domain.Common;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator.Enums;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.Entities.IngredientGeneralAggregator;

public class IngredientGeneral : BaseAuditableEntity, IsSoftDeleted
{
    public string IngredientName { get; set; } = string.Empty;
    public string IngredientDescription { get; set; } = string.Empty;
    public IngredientType? IngredientType { get; set; }
    public Guid IngredientTypeId { get; set; }
    public Status Status { get; set; } = Status.Active;
    public IngredientMeasure IngredientMeasure { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; }
    public virtual ICollection<DishIngredientGeneral>? DishIngredientGenerals { get; set; }

    public IngredientGeneral()
    {

    }

    public IngredientGeneral(string name, string description, Guid ingredientType, IngredientMeasure ingredientMeasure)
    {
        IngredientName = name;
        IngredientMeasure = ingredientMeasure;
        IngredientDescription = description;
        IngredientTypeId = ingredientType;
        Created = DateTime.Now;
    }

    public void Update(string name, string description, Guid ingredientType)
    {
        IngredientName = name;
        IngredientDescription = description;
        IngredientTypeId = ingredientType;
    }

    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }
}
