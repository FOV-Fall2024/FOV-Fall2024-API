﻿using FOV.Domain.Common;
using FOV.Domain.Entities.ComboAggregator.Enums;
using FOV.Domain.Entities.ProductAggregator;

namespace FOV.Domain.Entities.ComboAggregator;

public class ProductCombo : BaseAuditableEntity, IsSoftDeleted
{
    public Combo? Combo { get; set; }

    public Guid ComboId { get; set; }

    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public bool IsDeleted { get; set; }
}
