﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;
using FOV.Domain.Entities.DishAggregator.Enums;
using FOV.Domain.Entities.OrderAggregator;

namespace FOV.Domain.Entities.DishAggregator;
public class RefundDishInventoryTransaction : BaseAuditableEntity
{
    public int Quantity { get; set; }

    public DateTime? TransactionDate { get; set; } = DateTime.UtcNow;   

    public RefundDishInventory? RefundDishInventory { get; set; }

    public Guid RefundDishInventoryId { get; set; }

    public Order? Order { get; set; }
    public RefundDishInventoryTransactionType RefundDishInventoryTransactionType { get; set; }
    public Guid? OrderId { get; set; }

    public RefundDishInventoryTransaction(int Quantity)
    {

    }

    public RefundDishInventoryTransaction(int quantity, Guid refundDishInventoryId, RefundDishInventoryTransactionType type)
    {
        Quantity = quantity;
        RefundDishInventoryTransactionType = type;
        RefundDishInventoryId = refundDishInventoryId;
    }


}
