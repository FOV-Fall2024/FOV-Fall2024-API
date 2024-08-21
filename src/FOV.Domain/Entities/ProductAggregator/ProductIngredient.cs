using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientAggregator;

namespace FOV.Domain.Entities.ProductAggregator;
public class ProductIngredient : BaseAuditableEntity
{
    public Product? Product { get; set; }

    public Guid ProductId { get; set; }

    public decimal Quantity { get; set; }
    public Ingredient? Ingredient { get; set; }

    public Guid IngredientId { get; set; }

    public ProductIngredient()
    {

    }

    public ProductIngredient(Guid productId, Guid ingredientId)
    {
        IngredientId = ingredientId;
        ProductId = productId;
    }
}
