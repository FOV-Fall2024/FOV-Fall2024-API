using FOV.Domain.Common;

namespace FOV.Domain.Entities.IngredientAggregator;
public class IngredientRequestDetail: BaseAuditableEntity 
{
    public IngredientRequest? IngredientRequest { get; set; }

    public Guid IngredientRequestId { get; set; }

    public Ingredient? Ingredient { get; set; }

    public Guid IngredientId { get; set; }

    public IngredientRequestDetail()
    {
        
    }
}
