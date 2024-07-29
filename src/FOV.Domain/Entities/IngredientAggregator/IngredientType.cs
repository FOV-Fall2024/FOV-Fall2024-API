using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientGeneralAggregator;


namespace FOV.Domain.Entities.IngredientAggregator;

public class IngredientType : BaseAuditableEntity, IsSoftDeleted
{
    public string IngredientName { get; set; }
    public string IngredientDescription { get; set; } = string.Empty;

    public string IngredientMain { get; set; } = string.Empty;
    public Guid? ParentId { get; set; } = null;

    public int Left { get; set; }

    public int Right { get; set; }
    public int ExpiredTime { get; set; }

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
        ExpiredTime = 1;
        Left = 1;
        Right = 2;
        Created = DateTime.UtcNow;
        ParentId = null;
        IngredientMain = ingredientName;
    }

    public IngredientType(string name, string des, int right, string main, Guid parentId)
    {
        IngredientName = name;
        IngredientDescription = des;
        Right = right + 1;
        Left = right;
        ParentId = parentId;
        IngredientMain = main;
    }

    public void Update(string ingredientName, string ingrendientDescription)
    {
        IngredientName = ingredientName;
        IngredientDescription = ingrendientDescription;
    }

    public void UpdateState(bool state) => IsDeleted = state;


}
