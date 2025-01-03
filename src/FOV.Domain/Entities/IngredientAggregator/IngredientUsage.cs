﻿using FOV.Domain.Common;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.IngredientAggregator.Enums;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.Entities.IngredientAggregator;
public class IngredientUsage : BaseAuditableEntity, IsSoftDeleted
{
    public decimal Quantity { get; set; }

    public DateTime? TransactionDate { get; set; } = DateTime.UtcNow;

    public IngredientTransactionType Type { get; set; }

    public Ingredient? Ingredient { get; set; }

    public Guid IngredientId { get; set; }
    
    //public Dish Dish { get; set; } ????????????????????????????????????????????????????????????????????????????

    //public Guid DishId { get; set; } cai nay lam gi z chu ????? cai nay tui hoi, khong phai la chui chu, dung hieu nham

    public Status Status { get; set; }
    public OrderDetail? OrderDetail { get; set; }

    public Guid? OrderdDetailId { get; set; }


    public IngredientUsage()
    {

    }

    public IngredientUsage(decimal quantity, IngredientTransactionType type, Guid ingredientId)
    {
        Quantity = quantity;
        Type = type;
        IngredientId = ingredientId;
        TransactionDate = DateTime.UtcNow;
    }

    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }

}
