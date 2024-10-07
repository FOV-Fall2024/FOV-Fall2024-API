using FOV.Domain.Common;

namespace FOV.Domain.Entities.DishAggregator;
public class RefundDishUnit : BaseAuditableEntity
{
    public RefundDishInventory? RefundDishInventory { get; set; }

    public Guid RefundDishInventoryId { get; set; }

    public string UnitName { get; set; } = string.Empty;

    public int ConversionFactor { get; set; } = 0;


    public Guid? RefundDishUnitParentId { get; set; }

    public RefundDishUnit? RefundDishUnitParent { get; set; }

    public virtual ICollection<RefundDishUnit> RefundDishChildUnits { get; set; } = [];

    public RefundDishUnit(Guid refundDishInventoryId)
    {
        UnitName = "can";
        ConversionFactor = 1;
        RefundDishInventoryId = refundDishInventoryId;

    }

    public RefundDishUnit(Guid refundDishInventoryId, int conversionFactor, string unitName)
    {
        RefundDishInventoryId = refundDishInventoryId;
        ConversionFactor = conversionFactor;
        UnitName = unitName;
        
    }

    public void Update(string unitName,int conversionFactor)
    {
        UnitName = unitName;
        ConversionFactor = conversionFactor;
    }


}
