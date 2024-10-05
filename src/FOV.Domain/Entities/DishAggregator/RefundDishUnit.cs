using FOV.Domain.Common;

namespace FOV.Domain.Entities.DishAggregator;
public class RefundDishUnit : BaseAuditableEntity
{
    public RefundDishInventory? RefundDishInventory { get; set; }

    public Guid RefundDishInventoryId { get; set; }

    public string UnitName { get; set; } = string.Empty;

    public decimal? ConversionFactor { get; set; }


    public Guid? RefundDishUnitParentId { get; set; }

    public RefundDishUnit? RefundDishUnitParent { get; set; }

    public virtual ICollection<RefundDishUnit> RefundDishChildUnits { get; set; } = [];


}
