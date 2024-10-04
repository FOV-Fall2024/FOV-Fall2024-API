using FOV.Domain.Common;

namespace FOV.Domain.Entities.DishAggregator;
internal class RefundDishInventory : BaseAuditableEntity
{
    public int QuantityAvailable { get; set; }

    public Dish? Dish { get; set; }

    public Guid DishId { get; set; }


}
