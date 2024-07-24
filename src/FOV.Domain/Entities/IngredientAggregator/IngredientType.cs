using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientGeneralAggregator;


namespace FOV.Domain.Entities.IngredientAggregator;

public class IngredientType : BaseAuditableEntity, IsSoftDeleted
{
    public string IngredientName { get; set; }
    public string IngredientDescription { get; set; } = string.Empty;
    public Guid? ParentId { get; private set; }

    public int Left { get; set; }

    public int Right { get; set; }
    public int ExpiredTime { get; set; }

    public virtual ICollection<Ingredient>? Ingredients { get; set; }

    public virtual ICollection<IngredientGeneral>? IngredientGenerals { get; set; }
    public bool IsDeleted { get; set; }
    public IngredientType()
    {

    }


    //? Create New Ingredient Type Parent
    public IngredientType(string IngredientName, string IngredientDescription)
    {
        this.IngredientName = IngredientName;
        this.IngredientDescription = IngredientDescription;
        ExpiredTime = 1;
        Left = 1;
        Right = 2;
        Created = DateTime.UtcNow;
        ParentId = null;
    }

    public void Update(string IngredientName, string IngrendientDescription)
    {
        this.IngredientName = IngredientName;
        this.IngredientDescription = IngrendientDescription;
    }

    public void UpdateState(bool state) => IsDeleted = state;


}
