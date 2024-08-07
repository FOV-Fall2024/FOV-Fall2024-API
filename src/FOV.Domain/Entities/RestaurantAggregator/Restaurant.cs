﻿using FOV.Domain.Common;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Domain.Entities.RestaurantAggregator.Enums;
using FOV.Domain.Entities.TableAggregator;
using FOV.Domain.Entities.UserAggregator;

namespace FOV.Domain.Entities.RestaurantAggregator;

public class Restaurant : BaseAuditableEntity, IsSoftDeleted
{
    public string RestaurantName { get; set; }
    public string Address { get; set; }

    public Status Status { get; set; }
    public string RestaurantPhone { get; set; }

    public string RestataurantCode { get; set; }


    public virtual ICollection<Employee> Employees { get; set; } = [];
    public virtual ICollection<Ingredient> Ingredients { get; set; } = [];

    public virtual ICollection<Product> Products { get; set; } = [];
    public virtual ICollection<Table> Tables { get; set; } = [];
    public virtual ICollection<Combo> Combos { get; set; } = [];
    public bool IsDeleted { get; set; }

    public Restaurant()
    {

    }

    public Restaurant(string name, string address, string phone, string code)
    {
        RestaurantName = name;
        Address = address;
        RestaurantPhone = phone;
        RestataurantCode = code;
    }
}
