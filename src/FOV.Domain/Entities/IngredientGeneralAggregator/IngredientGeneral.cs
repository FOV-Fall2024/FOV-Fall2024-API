using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.ProductGeneralAggregator;

namespace FOV.Domain.Entities.IngredientGeneralAggregator;

public class IngredientGeneral : BaseAuditableEntity, IsSoftDeleted
{
    public string IngredientName { get; set; } = string.Empty;
    public string IngredientDescription { get; set; } = string.Empty;
    public IngredientType? IngredientType { get; set; }
    public Guid IngredientTypeId { get; set; }
    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<ProductIngredientGeneral>? ProductIngredientGenerals { get; set; }

    public IngredientGeneral()
    {

    }

    public IngredientGeneral(string Name, string Description, Guid IngredientType)
    {
        IngredientName = Name;
        IngredientDescription = Description;
        IngredientTypeId = IngredientType;
        Created = DateTime.Now;
    }

    public void Update(string Name, string Description, Guid IngredientType)
    {
        IngredientName = Name;
        IngredientDescription = Description;
        IngredientTypeId = IngredientType;
    }

    public void UpdateState(bool isDelete) => IsDeleted = isDelete;
}
