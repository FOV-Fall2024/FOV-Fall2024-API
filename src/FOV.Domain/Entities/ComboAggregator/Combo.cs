using FOV.Domain.Common;
using FOV.Domain.Entities.ComboAggregator.Enums;
using FOV.Domain.Entities.RestaurantAggregator;

namespace FOV.Domain.Entities.ComboAggregator;

public class Combo : BaseAuditableEntity, IsSoftDeleted
{
    public required string ComboName { get; set; }

    public required Status Status { get; set; }
    public bool IsDeleted { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public DateTime ExpiredDate { get; set; }

    public Restaurant? Restaurant { get; set; }

    public Guid RestaurantId { get; set; }

    public ICollection<ProductCombo> ProductCombos { get; set; } = [];
}
