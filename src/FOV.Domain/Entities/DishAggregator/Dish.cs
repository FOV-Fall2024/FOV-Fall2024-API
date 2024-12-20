﻿using FOV.Domain.Common;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.DishAggregator.Enums;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.DishGeneralAggregator.Enums;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.Entities.DishAggregator;

public class Dish : BaseAuditableEntity, IsSoftDeleted
{
    public DishType DishType { get; set; }
    public PriorityDish PriorityDish { get; set; }
    public virtual ICollection<DishCombo> DishCombos { get; set; } = [];
    public ICollection<OrderDetail> OrderDetails { get; set; } = [];
    public virtual ICollection<DishIngredient> DishIngredients { get; set; } = [];
    public Category? Category { get; set; }
    public Guid? CategoryId { get; set; }
    public Status Status { get; set; }

    public decimal? Price { get; set; }
    public Restaurant? Restaurant { get; set; }

    public Guid RestaurantId { get; set; }

    public DishGeneral? DishGeneral { get; set; }

    public Guid? DishGeneralId { get; set; }
    public RefundDishInventory? RefundDishInventory { get; set; }

    public Dish()
    {

    }

    public Dish(decimal price, Guid restaurantId, Guid? categoryId, Guid dishGeneralId,Status status)
    {
        Price = price;
        CategoryId = categoryId;
        Status = status;
        RestaurantId = restaurantId;
        DishGeneralId = dishGeneralId;
    }

    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }

    public void Update(decimal dishPrice) => Price = dishPrice;


}
