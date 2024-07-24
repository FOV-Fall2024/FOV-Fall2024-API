using FOV.Domain.Common;
using FOV.Domain.Entities.ProductGeneralAggregator;

namespace FOV.Domain.Entities.ProductAggregator;

public class Category : BaseAuditableEntity
{
    public required string CategoryName { get; set; }

    public int Left { get; set; }

    public int Right { get; set; }

    public Guid CategoryParentId { get; set; }

    public string? CategoryMain { get; set; }

    public virtual ICollection<ProductGeneral> ProductGenerals { get; set; } = [];

    public virtual ICollection<Product> Products { get; set; } = [];

}
