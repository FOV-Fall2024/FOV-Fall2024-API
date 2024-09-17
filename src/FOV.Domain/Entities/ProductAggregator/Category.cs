using FOV.Domain.Common;
using FOV.Domain.Entities.ProductAggregator.Enums;
using FOV.Domain.Entities.ProductGeneralAggregator;

namespace FOV.Domain.Entities.ProductAggregator;

public class Category : BaseAuditableEntity, IsSoftDeleted
{
    public string CategoryName { get; set; } = string.Empty;
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
    }


    // Add New Children Category

    public void Update(string categoryName)
    {
        CategoryName = categoryName;
    }

    public void SetState(bool isDelete) => IsDeleted = isDelete;

}
