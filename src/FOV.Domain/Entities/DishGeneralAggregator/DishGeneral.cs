using FOV.Domain.Common;
using FOV.Domain.Entities.DishAggregator;


namespace FOV.Domain.Entities.DishGeneralAggregator;

public class DishGeneral : BaseAuditableEntity, IsSoftDeleted
{

    public string DishName { get; set; } = string.Empty;

    public string DishDescription { get; set; } = string.Empty;

    public string DishImageDefault { get; set; } = string.Empty;
    public virtual ICollection<Dish> Dishes { get; set; } = [];
    public Category Category { get; set; }
    public Guid? CategoryId { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsDraft { get; set; } = true;
    public virtual ICollection<DishIngredientGeneral> Ingredients { get; set; } = [];


    public DishGeneral()
    {

    }

    public DishGeneral(string name, string description, Guid categoryId, string image, bool isDraft)
    {
        IsDraft = isDraft;
        DishImageDefault = image;
        DishName = name;
        DishDescription = description;
        CategoryId = categoryId;
        IsDeleted = false;
        Id = Guid.NewGuid();
    }

    public void Update(string name, string description, Guid categoryId)
    {
        DishName = name;
        DishDescription = description;
        CategoryId = categoryId;
    }

    public void Update(string name, string description, string Image)
    {
        DishName = name;
        DishDescription = description;
        DishImageDefault = Image;
    }

    public void Update(string name, string description, string Image, Guid categoryId)
    {
        DishName = name;
        DishDescription = description;
        DishImageDefault = Image;
        CategoryId = categoryId;
    }





    public void SetState(bool isDeleted) => IsDeleted = isDeleted;

    public void SetDraftState(bool isDraftState) => IsDraft = isDraftState;
}
