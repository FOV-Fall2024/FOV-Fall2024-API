using FOV.Domain.Common;
using FOV.Domain.Entities.DishAggregator;

namespace FOV.Domain.Entities.DishAggregator;
public class DishImage : BaseAuditableEntity
{
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsMain { get; set; } = false;

    public Dish? Dish { get; set; }

    public Guid DishId { get; set; }
}
