using FOV.Domain.Common;
using FOV.Domain.Entities.ComboAggregator.Enums;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.RestaurantAggregator;

namespace FOV.Domain.Entities.ComboAggregator;

public class Combo : BaseAuditableEntity, IsSoftDeleted
{
    public string ComboName { get; set; }

    public Status Status { get; set; }
    public bool IsDeleted { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal PercentReduce { get; set; }

    public DateTime ExpiredDate { get; set; }

    public Restaurant? Restaurant { get; set; }

    public Guid RestaurantId { get; set; }

    public ICollection<ProductCombo> ProductCombos { get; set; } = [];
    public ICollection<OrderDetail> OrderDetails { get; set; } = [];

    public Combo()
    {

    }
    public Combo(string comboName, int quantity, decimal price, DateTime expiredDate, Guid restaurantId)
    {
        ComboName = comboName;
        Status = Status.InStock;
        Quantity = quantity;
        Price = price;
        ExpiredDate = expiredDate;
        RestaurantId = restaurantId;
    }



    public void UpdateState(bool isDeleted) => IsDeleted = isDeleted;
}
