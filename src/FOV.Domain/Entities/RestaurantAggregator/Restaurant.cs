using FOV.Domain.Common;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Domain.Entities.RestaurantAggregator.Enums;
using FOV.Domain.Entities.TableAggregator;

namespace FOV.Domain.Entities.RestaurantAggregator;

public class Restaurant : BaseAuditableEntity, IsSoftDeleted
{
    public required string RestaurantName { get; set; }
    public required string Address { get; set; }

    public Status Status { get; set; }
    public required string RestaurantPhone { get; set; }

    public required string RestataurantCode { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; } = [];

    public virtual ICollection<Product> Products { get; set; } = [];
    public virtual ICollection<Table> Tables { get; set; } = [];
    public virtual ICollection<Combo> Combos { get; set; } = [];
    public bool IsDeleted { get; set; }
}
