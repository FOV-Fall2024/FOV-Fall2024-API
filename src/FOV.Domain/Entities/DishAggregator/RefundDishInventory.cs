using FOV.Domain.Common;

namespace FOV.Domain.Entities.DishAggregator;
public class RefundDishInventory : BaseAuditableEntity
{
    public int QuantityAvailable { get; set; }

    public Dish? Dish { get; set; }

    public Guid DishId { get; set; }
    public virtual ICollection<RefundDishUnit> DishUnits { get; set; } = [];

    public virtual ICollection<RefundDishInventoryTransaction> Transaction { get; set; }


}
