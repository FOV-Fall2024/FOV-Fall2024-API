using FOV.Domain.Common;
using FOV.Domain.Entities.ProductAggregator;


namespace FOV.Domain.Entities.ProductGeneralAggregator;

public class ProductGeneral : BaseAuditableEntity, IsSoftDeleted
{

    public string ProductName { get; set; } = string.Empty;

    public string ProductDescription { get; set; } = string.Empty;

    public Category? Category { get; set; }
    public virtual ICollection<Product> Products { get; set; } = [];
    public Guid? CategoryId { get; set; }
    public bool IsDeleted { get; set; }

    public virtual ICollection<ProductIngredientGeneral> Ingredients { get; set; } = [];


    public ProductGeneral()
    {

    }

    public ProductGeneral(string name, string description, Guid categoryId)
    {
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

    public void SetState(bool isDeleted) => IsDeleted = isDeleted;
}
