

using FOV.Domain.Common;

namespace FOV.Domain.Entities.IngredientAggregator;

public class IngredientGeneral : BaseEntity
{
    public string IngredientName { get; set; } = string.Empty;

    public IngredientType? IngredientType { get; set; }
    public Guid IngredientTypeId { get; set; }

}
