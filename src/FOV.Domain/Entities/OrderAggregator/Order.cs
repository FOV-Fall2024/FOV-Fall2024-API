using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.PaymentAggregator;
using FOV.Domain.Entities.TableAggregator;

namespace FOV.Domain.Entities.OrderAggregator;

public class Order : BaseAuditableEntity
{
    public OrderStatus? OrderStatus { get; set; }
    public OrderType? OrderType { get; set; }
    public DateTime? OrderTime { get; set; }
    public decimal TotalPrice { get; set; }
    public Table? Table { get; set; }
    public Guid TableId { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } = [];
    public ICollection<Payments> Payments { get; set; } = [];

    public virtual ICollection<IngredientTransaction> IngredientTransactions { get; set; } = [];
    public Order()
    {

    }
    public Order(OrderType orderType, DateTime orderTime, decimal totalPrice)
    {
        this.OrderType = orderType;
        this.OrderTime = orderTime;
        this.TotalPrice = totalPrice;
    }
    public void Update(OrderStatus orderStatus, OrderType orderType, DateTime orderTime, decimal totalPrice, Guid tableId)
    {
        this.OrderStatus = orderStatus;
        this.OrderType = orderType;
        this.OrderTime = orderTime;
        this.TotalPrice = totalPrice;
        this.TableId = tableId;
    }


}
