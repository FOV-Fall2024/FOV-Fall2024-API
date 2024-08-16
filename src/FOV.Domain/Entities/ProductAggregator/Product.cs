using FOV.Domain.Common;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Domain.Entities.RestaurantAggregator;

namespace FOV.Domain.Entities.ProductAggregator;

public class Product : BaseAuditableEntity, IsSoftDeleted
{
    public string ProductName { get; set; } = string.Empty;

    public string ProductDescription { get; set; } = string.Empty;

    public virtual ICollection<ProductCombo> ProductCombos { get; set; } = [];
    public ICollection<OrderDetail> OrderDetails { get; set; } = []; 
    public Category? Category { get; set; }
    public Guid? CategoryId { get; set; }

    public Restaurant? Restaurant { get; set; }

    public Guid RestaurantId { get; set; }

    public ProductGeneral? ProductGeneral { get; set; }

    public Guid? ProductGeneralId { get; set; }
    public bool IsDeleted { get; set; }

    public Product()
    {

    }

    public Product(string name, Guid restaurantId, Guid? categoryId, Guid produuctGeneralId)
    {
        ProductName = name;
        CategoryId = categoryId;
        RestaurantId = restaurantId;
        ProductGeneralId = produuctGeneralId;

    }

    public void UpdateState(bool isDelete) => IsDeleted = isDelete;

    public void Update(string name, string description)
    {
        ProductName = name;
        ProductDescription = description;
    }
}
