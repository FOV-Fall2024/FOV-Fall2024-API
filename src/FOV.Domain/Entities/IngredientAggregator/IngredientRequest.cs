using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;

namespace FOV.Domain.Entities.IngredientAggregator;
public class IngredientRequest : BaseAuditableEntity
{
    public string RequestCode { get; set; } = string.Empty;
    public virtual ICollection<IngredientRequestDetail> IngredientRequestDetails
    { get; set; }

    public IngredientRequestType Type { get; set; }
    public User? User { get; set; }
    public string UserId { get; set; }
    public IngredientRequest()
    {

    }
}
