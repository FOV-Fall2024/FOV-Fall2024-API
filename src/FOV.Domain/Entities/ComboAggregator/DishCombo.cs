using FOV.Domain.Common;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.Entities.ComboAggregator;

public class DishCombo : BaseAuditableEntity, IsSoftDeleted
{
    public Combo? Combo { get; set; }

    public int Quantity { get; set; } = 1;

    public Guid ComboId { get; set; }

    public Guid DishId { get; set; }
    public Dish? Dish { get; set; }
    public Status Status { get; set; }

    public DishCombo()
    {

    }



    public DishCombo(Guid dishId, Guid comboId, int quantity)
    {
        ComboId = comboId;
        DishId = dishId;
        Quantity = quantity;

    }

    public void AddQuantity(int quantity) => Quantity += quantity;

    public void UpdateQuantity(int quantity) => Quantity = quantity;
    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }

}
