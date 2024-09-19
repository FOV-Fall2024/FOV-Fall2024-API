using FOV.Domain.Common;
using FOV.Domain.Entities.NewProductRecommendAggregator.Enums;
using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Domain.Entities.RestaurantAggregator;

namespace FOV.Domain.Entities.NewProductRecommendAggregator;
public class NewProductRecommend : BaseAuditableEntity
{

    public Restaurant? Restaurant { get; set; }

    public Guid RestaurantId { get; set; }

    public ProductGeneral? ProductGeneral { get; set; }

    public Guid ProductGeneralId { get; set; }


    public NewProductRecommendStatus Status { get; set; }

    public virtual ICollection<NewProductRecommendLog> Log { get; set; } = [];

    public NewProductRecommend()
    {
        
    }

    public NewProductRecommend(Guid restaurantId,Guid productGeneralId,NewProductRecommendStatus status)
    {
        
    }

    public void UpdateState(NewProductRecommendStatus status) => Status = status;
}
