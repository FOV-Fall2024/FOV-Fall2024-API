using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.ProductAggregator;

namespace FOV.Domain.Entities.OrderAggregator;
public class OrderDetail : BaseAuditableEntity
{
    public Guid? ComboId { get; set; }
    public Guid? ProductId { get; set; }
    public Guid? OrderId { get; set; }
    public string? Status { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Combo? Combo { get; set; }
    public Product? Product { get; set; }
    public Order? Order { get; set; }
    public OrderDetail()
    {

    }
    public OrderDetail(Guid? comboId, Guid? productId, Guid? orderId, string status, int quantity, decimal price)
    {
        this.ComboId = comboId;
        this.ProductId = productId;
        this.OrderId = orderId;
        this.Status = status;
        this.Quantity = quantity;
        this.Price = price;
    }
    public void Update(Guid? comboId, Guid? productId, string status, int quantity, decimal price)
    {
        this.ComboId = comboId;
        this.ProductId = productId;
        this.Status = status;
        this.Quantity = quantity;
        this.Price = price;
    }
}
