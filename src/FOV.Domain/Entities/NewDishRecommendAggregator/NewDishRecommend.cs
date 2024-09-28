using FOV.Domain.Common;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.NewDishRecommendAggregator.Enums;
using FOV.Domain.Entities.RestaurantAggregator;

namespace FOV.Domain.Entities.NewDishRecommendAggregator;
public class NewDishRecommend : BaseAuditableEntity
{

    public Restaurant? Restaurant { get; set; }

    public Guid RestaurantId { get; set; }

    public DishGeneral? DishGeneral { get; set; }

    public Guid DishGeneralId { get; set; }


    public NewProductRecommendStatus Status { get; set; }

    public virtual ICollection<NewDishRecommendLog> Log { get; set; } = [];

    public NewDishRecommend()
    {

    }

    public NewDishRecommend(Guid restaurantId, Guid dishGeneralId, NewProductRecommendStatus status)
    {
        RestaurantId = restaurantId;
        DishGeneralId = dishGeneralId;
        Status = status;
    }

    public void UpdateState(NewProductRecommendStatus status) => Status = status;
}
