using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;


namespace FOV.Domain.Entities.IngredientAggregator;

public class IngredientType : BaseAuditableEntity, IsSoftDeleted
{
    public string IngredientName { get; set; }
    public string IngredientDescription { get; set; } = string.Empty;
    public virtual ICollection<IngredientGeneral>? IngredientGenerals { get; set; } = [];
    public Status Status { get; set; }

    public IngredientType()
    {

    }


    //? Create New Ingredient Type Parent
    public IngredientType(string ingredientName, string ingredientDescription)
    {
        IngredientName = ingredientName;
        IngredientDescription = ingredientDescription;
    }



    public void Update(string ingredientName, string ingredientDescription)
    {
        IngredientName = ingredientName;
        IngredientDescription = ingredientDescription;
    }

    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }
}
