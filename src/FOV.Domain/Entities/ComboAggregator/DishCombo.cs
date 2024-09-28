using FOV.Domain.Common;
using FOV.Domain.Entities.DishAggregator;

namespace FOV.Domain.Entities.ComboAggregator;

public class DishCombo : BaseAuditableEntity, IsSoftDeleted
{
    public Combo? Combo { get; set; }

    public Guid ComboId { get; set; }

    public Guid DishId { get; set; }
    public Dish? Dish { get; set; }
    public bool IsDeleted { get; set; }

    public DishCombo()
    {

    }



    public DishCombo(Guid dishId, Guid comboId)
    {
        ComboId = comboId;
        DishId = dishId;
        IsDeleted = false;
    }
}
