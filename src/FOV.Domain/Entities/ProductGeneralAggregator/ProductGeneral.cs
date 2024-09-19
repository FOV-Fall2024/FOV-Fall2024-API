using FOV.Domain.Common;
using FOV.Domain.Entities.ProductAggregator;


namespace FOV.Domain.Entities.ProductGeneralAggregator;

public class ProductGeneral : BaseAuditableEntity, IsSoftDeleted
{

    public string ProductName { get; set; } = string.Empty;

    public string ProductDescription { get; set; } = string.Empty;

    public string ProductImageDefault { get; set; } = string.Empty;
    public virtual ICollection<Product> Products { get; set; } = [];
    public Category Category { get; set; }
    public Guid? CategoryId { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsDraft { get; set; } = true;
    public virtual ICollection<ProductIngredientGeneral> Ingredients { get; set; } = [];


    public ProductGeneral()
    {

    }

    public ProductGeneral(string name, string description, Guid categoryId,string image,bool isDraft)
    {
        IsDraft = isDraft;
        ProductImageDefault = image;
        ProductName = name;
        ProductDescription = description;
        CategoryId = categoryId;
        IsDeleted = false;
        Id = Guid.NewGuid();
    }

    public void Update(string name, string description, Guid categoryId)
    {
        ProductName = name;
        ProductDescription = description;
        CategoryId = categoryId;
    }

    public void Update(string name, string description, string Image)
    {
        ProductName = name;
        ProductDescription = description;
        ProductImageDefault = Image;
    }

    public void Update(string name, string description, string Image,Guid categoryId)
    {
        ProductName = name;
        ProductDescription = description;
        ProductImageDefault = Image;
        CategoryId = categoryId;
    }





    public void SetState(bool isDeleted) => IsDeleted = isDeleted;

    public void SetDraftState(bool isDraftState) => IsDraft = isDraftState;
}
