﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;

namespace FOV.Domain.Entities.OrderAggregator;
public class OrderDetail : BaseAuditableEntity
{
    public Guid? ComboId { get; set; }
    public Guid? ProductId { get; set; }
    public Guid? OrderId { get; set; }
    public OrderDetailsStatus? Status { get; set; } = OrderDetailsStatus.Prepare;
    public int Quantity { get; set; }
    public int RefundQuantity { get; set; } = 0;
    public bool IsRefund { get; set; } = false;
    public decimal Price { get; set; }
    public string? Note { get; set; }
    public Combo? Combo { get; set; }
    public Dish? Dish { get; set; }
    public Order? Order { get; set; }
    public virtual ICollection<OrderResponsibility> OrderResponsibilities { get; set; } = [];
    public bool IsAddMore { get; set; } = false;
    public OrderDetail()
    {

    }
    public OrderDetail(Guid? comboId, Guid? productId, Guid? orderId, int quantity, decimal price, string note)
    {
        this.ComboId = comboId;
        this.ProductId = productId;
        this.OrderId = orderId;
        this.Quantity = quantity;
        this.Price = price;
        Note = note;
    }
    public void Update(Guid? comboId, Guid? productId, int quantity, decimal price, string note)
    {
        this.ComboId = comboId;
        this.ProductId = productId;
        this.Quantity = quantity;
        this.Price = price;
        Note = note;
    }
}
