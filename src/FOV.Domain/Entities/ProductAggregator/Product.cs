using FOV.Domain.Common;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.RestaurantAggregator;

namespace FOV.Domain.Entities.ProductAggregator;

public class Product : BaseAuditableEntity
{
    public required string ProductName { get; set; }

    public string ProductDescription { get; set; } = string.Empty;

    public virtual ICollection<ProductCombo> ProductCombos { get; set; } = [];
    public Category? Category { get; set; }
    public Guid CategoryId { get; set; }

    public Restaurant? Restaurant { get; set; }

    public Guid RestaurantId { get; set; }
}
