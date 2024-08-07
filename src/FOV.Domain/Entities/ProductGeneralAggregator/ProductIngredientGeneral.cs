﻿using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientGeneralAggregator;

namespace FOV.Domain.Entities.ProductGeneralAggregator;

public class ProductIngredientGeneral : BaseAuditableEntity, IsSoftDeleted
{
    public ProductGeneral ProductGeneral { get; set; } = default!;
    public Guid ProductGeneralId { get; set; }

    public IngredientGeneral IngredientGeneral { get; set; } = default!;

    public decimal Quantity { get; set; }
    public Guid IngredientGeneralId { get; set; }
    public bool IsDeleted { get; set; }

    public ProductIngredientGeneral()
    {

    }

    public ProductIngredientGeneral(Guid productGeneralId, Guid ingredientGeneralId, decimal Qunantity)
    {
        this.ProductGeneralId = productGeneralId;
        this.IngredientGeneralId = ingredientGeneralId;
        this.Quantity = Quantity;
    }

    public void Update(Guid productGeneralId, Guid ingredientGeneralId, decimal quantity)
    {
        this.ProductGeneralId = productGeneralId;
        this.IngredientGeneralId = ingredientGeneralId;
        this.Quantity = quantity;
    }
}
