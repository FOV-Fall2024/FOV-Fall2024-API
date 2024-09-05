using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientAggregator.Enums;
using FOV.Domain.Entities.OrderAggregator;

namespace FOV.Domain.Entities.IngredientAggregator;
public class IngredientTransaction : BaseAuditableEntity, IsSoftDeleted
{
    public decimal Quantity { get; set; }

    public DateTime TransactionDate { get; set; }

    public IngredientTransactionType Type { get; set; }

    public Ingredient? Ingredient { get; set; }

    public Guid IngredientId { get; set; }

    public bool IsDeleted { get; set; }


    public Order? Order { get; set; }

    public Guid? OrderId { get; set; }


    public IngredientTransaction()
    {

    }

    public IngredientTransaction(decimal quantity, IngredientTransactionType type, Guid ingredientId)
    {
        Quantity = quantity;
        Type = type;
        IngredientId = ingredientId;
        TransactionDate = DateTime.UtcNow;
    }



}
