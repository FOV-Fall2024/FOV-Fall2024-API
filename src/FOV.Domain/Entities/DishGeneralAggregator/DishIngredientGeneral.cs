using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.Entities.DishGeneralAggregator;

public class DishIngredientGeneral : BaseAuditableEntity, IsSoftDeleted
{
    public DishGeneral DishGeneral { get; set; } = default!;
    public Guid DishGeneralId { get; set; }

    public IngredientGeneral IngredientGeneral { get; set; } = default!;

    public decimal Quantity { get; set; }
    public Guid IngredientGeneralId { get; set; }
    public Status Status { get; set; }

    public DishIngredientGeneral()
    {

    }

    public DishIngredientGeneral(Guid dishGeneralId, Guid ingredientGeneralId, decimal quantity)
    {
        this.DishGeneralId = dishGeneralId;
        this.IngredientGeneralId = ingredientGeneralId;
        this.Quantity = quantity;
    }

    public void Update(Guid dishGeneralId, Guid ingredientGeneralId, decimal quantity)
    {
        this.DishGeneralId = dishGeneralId;
        this.IngredientGeneralId = ingredientGeneralId;
        this.Quantity = quantity;
    }
    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }

    public void UpdateQuantity(decimal quantity) => Quantity = quantity;
}
