using FOV.Domain.Common;
using FOV.Domain.Entities.ComboAggregator.Enums;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.Entities.ComboAggregator;

public class Combo : BaseAuditableEntity, IsSoftDeleted
{
    public string ComboName { get; set; }
    public string? ComboDescription { get; set; }

    public ComboStatus ComboStatus { get; set; }
    public Status Status { get; set; } //For filter
    public decimal Price { get; set; }
    public string? Thumbnail { get; set; }
    public decimal PercentReduce { get; set; }
    public Restaurant? Restaurant { get; set; }
    public Guid RestaurantId { get; set; }
    public ICollection<DishCombo> DishCombos { get; set; } = [];
    public ICollection<OrderDetail> OrderDetails { get; set; } = [];

    public Combo()
    {

    }
    public Combo(string comboName, decimal price, Guid restaurantId, string thumbnail, string description)
    {
        Thumbnail = thumbnail;
        ComboName = comboName;
        ComboDescription = description;
        ComboStatus = ComboStatus.InStock;
        Status = Status.Active;
        Price = price;
        RestaurantId = restaurantId;
    }



    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }

    public void Update(string comboName, string comboDescription, string thumbnail, decimal price)
    {
        ComboName = comboName;
        ComboDescription = comboDescription;
        Thumbnail = thumbnail;
        Price = price;
    }

    public void Update(decimal price) => Price = price; 
}
