using FOV.Domain.Common;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.TableAggregator;

namespace FOV.Domain.Entities.OrderAggregator;

public class Order : BaseAuditableEntity
{
    public string? OrderStatus { get; set; }
    public string? OrderType { get; set; }
    public DateTime? OrderTime { get; set; }
    public decimal? TotalPrice { get; set; }
    public Table? Table { get; set; }
    public Guid TableId { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } = [];
    public Order()
    {

    }
    public Order(string orderStatus, string orderType, DateTime orderTime, decimal totalPrice)
    {
        this.OrderStatus = orderStatus;
        this.OrderType = orderType;
        this.OrderTime = orderTime;
        this.TotalPrice = totalPrice;
    }
    public void Update(string orderStatus, string orderType, DateTime orderTime, decimal totalPrice, Guid tableId)
    {
        this.OrderStatus = orderStatus;
        this.OrderType = orderType;
        this.OrderTime = orderTime;
        this.TotalPrice = totalPrice;
        this.TableId = tableId;
    }


}
