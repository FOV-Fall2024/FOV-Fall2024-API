﻿using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientAggregator;

namespace FOV.Domain.Entities.DishAggregator;
public class DishIngredient : BaseAuditableEntity
{
    public Dish? Dish { get; set; }

    public Guid DishId { get; set; }

    public decimal Quantity { get; set; }
    public Ingredient? Ingredient { get; set; }

    public Guid IngredientId { get; set; }

    public DishIngredient()
    {

    }

    public DishIngredient(Guid dishId, Guid ingredientId)
    {
        IngredientId = ingredientId;
        DishId = dishId;
    }
}