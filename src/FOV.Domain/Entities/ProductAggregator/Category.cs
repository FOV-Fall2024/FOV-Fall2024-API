using FOV.Domain.Common;
using FOV.Domain.Entities.ProductGeneralAggregator;

namespace FOV.Domain.Entities.ProductAggregator;

public class Category : BaseAuditableEntity, IsSoftDeleted
{
    public string CategoryName { get; set; } = string.Empty;

    public int Left { get; set; }

    public int Right { get; set; }

    public Guid? CategoryParentId { get; set; }

    public string CategoryMain { get; set; }

    public virtual ICollection<ProductGeneral> ProductGenerals { get; set; } = [];

    public virtual ICollection<Product> Products { get; set; } = [];
    public bool IsDeleted { get; set; }

    public Category()
    {

    }

    // Add New Parent Category
    public Category(string name)
    {
        CategoryName = name;
        CategoryParentId = null;
        CategoryMain = name;
        Left = 1;
        Right = 2;
    }


    // Add New Child Category 
    public Category(string name, Guid parentId, string main, int left, int right)
    {
        CategoryName = name;
        CategoryParentId = parentId;
        CategoryMain = main;
        Left = left;
        Right = right;
    }


    // Add New Children Category

    public void Update(string categoryName)
    {
        CategoryName = categoryName;
    }

    public void SetState(bool isDelete) => IsDeleted = isDelete;

}
