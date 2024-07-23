using FOV.Domain.Common;
using FOV.Domain.Entities.ProductAggregator;


namespace FOV.Domain.Entities.ProductGeneralAggregator;

public class ProductGeneral : BaseAuditableEntity, IsSoftDeleted
{
    public required string ProductName { get; set; }

    public string ProductDescription { get; set; } = string.Empty;

    public Category? Category { get; set; } 

    public Guid CategoryId { get; set; }
    public bool IsDeleted { get;  set; }

    public virtual ICollection<ProductIngredientGeneral> Ingredients { get; set; } = [];
}
