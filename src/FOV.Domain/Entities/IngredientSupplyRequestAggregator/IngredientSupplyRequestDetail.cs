using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientAggregator;

namespace FOV.Domain.Entities.IngredientSupplyRequestAggregator;
public class IngredientSupplyRequestDetail : BaseAuditableEntity
{
    public Ingredient? Ingredient { get; set; }
    public Guid IngredientId { get; set; }
    public IngredientSupplyRequest? IngredientSupplyRequest { get; set; }
    public Guid IngredientSupplyRequestId { get; set; }

    public IngredientSupplyRequestDetail()
    {
        
    }

}
