using FOV.Domain.Common;

namespace FOV.Domain.Entities.ProductAggregator;
public class ProductImage : BaseAuditableEntity 
{
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsMain { get; set; } = false;
    
    public Product? Product { get; set; }

    public Guid ProductId { get; set; }
}
