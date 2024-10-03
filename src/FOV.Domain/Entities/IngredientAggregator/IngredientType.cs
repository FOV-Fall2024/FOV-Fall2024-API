using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientGeneralAggregator;


namespace FOV.Domain.Entities.IngredientAggregator;

public class IngredientType : BaseAuditableEntity, IsSoftDeleted
{
    public string IngredientName { get; set; }
    public string IngredientDescription { get; set; } = string.Empty;

    public virtual ICollection<Ingredient>? Ingredients { get; set; } = [];

    public virtual ICollection<IngredientGeneral>? IngredientGenerals { get; set; } = [];
    public bool IsDeleted { get; set; }
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

    public void UpdateState(bool state) => IsDeleted = state;


}
