using FOV.Domain.Common;
using FOV.Domain.Entities.ComboAggregator.Enums;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.Entities.ComboAggregator;

public class Combo : BaseAuditableEntity, IsSoftDeleted
{
    public string ComboName { get; set; }

    public ComboStatus ComboStatus { get; set; }
    public Status Status { get; set; } //For filter
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string? Thumbnail { get; set; }
    public decimal PercentReduce { get; set; }
    public DateTime? ExpiredDate { get; set; } = DateTime.UtcNow;
    public Restaurant? Restaurant { get; set; }
    public Guid RestaurantId { get; set; }
    public ICollection<DishCombo> DishCombos { get; set; } = [];
    public ICollection<OrderDetail> OrderDetails { get; set; } = [];

    public Combo()
    {

    }
    public Combo(string comboName, int quantity, decimal price, DateTime expiredDate, Guid restaurantId,string thumbnail)
    {
        Thumbnail = thumbnail;
        ComboName = comboName;
        ComboStatus = ComboStatus.InStock;
        Status = Status.Active;
        Quantity = quantity;
        Price = price;
        ExpiredDate = expiredDate;
        RestaurantId = restaurantId;
    }



    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }
}
