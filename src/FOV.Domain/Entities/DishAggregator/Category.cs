﻿using FOV.Domain.Common;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.Entities.DishAggregator;

public class Category : BaseAuditableEntity, IsSoftDeleted
{
    public string CategoryName { get; set; } = string.Empty;
    public virtual ICollection<DishGeneral> DishGenerals { get; set; } = [];

    public virtual ICollection<Dish> Dishes { get; set; } = [];
    public Status Status { get; set; }

    public Category()
    {

    }

    // Add New Parent Category
    public Category(string name)
    {
        CategoryName = name;
    }


    // Add New Children Category

    public void Update(string categoryName)
    {
        CategoryName = categoryName;
    }

    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }

}
