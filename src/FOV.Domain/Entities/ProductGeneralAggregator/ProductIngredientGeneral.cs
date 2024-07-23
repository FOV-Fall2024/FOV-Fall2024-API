using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientGeneralAggregator;

namespace FOV.Domain.Entities.ProductGeneralAggregator;

public class ProductIngredientGeneral : BaseAuditableEntity, IsSoftDeleted
{
    public ProductGeneral? ProductGeneral { get; set; }
    public Guid? ProductGeneralId { get; set; }

    public IngredientGeneral? IngredientGeneral { get; set; }

    public Guid? IngredientGeneralId { get; set; }
    public bool IsDeleted { get; set; }
}
