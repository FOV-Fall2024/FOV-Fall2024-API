using FOV.Domain.Common;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.DishAggregator.Enums;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.DishGeneralAggregator.Enums;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.Entities.DishAggregator;

public class Dish : BaseAuditableEntity, IsSoftDeleted
{
    public string DishName { get; set; } = string.Empty;

    public string DishDescription { get; set; } = string.Empty;

    public DishType DishType { get; set; }
    public PriorityDish PriorityDish { get; set; }
    public virtual ICollection<DishCombo> DishCombos { get; set; } = [];
    public ICollection<OrderDetail> OrderDetails { get; set; } = [];
    public virtual ICollection<DishImage> DishImages { get; set; } = [];
    public virtual ICollection<DishIngredient> DishIngredients { get; set; } = [];
    public Category? Category { get; set; }
    public Guid? CategoryId { get; set; }
    public Status Status { get; set; }

    public decimal? Price { get; set; }
    public Restaurant? Restaurant { get; set; }

    public Guid RestaurantId { get; set; }

    public DishGeneral? DishGeneral { get; set; }

    public Guid? DishGeneralId { get; set; }
    public RefundDishInventory? RefundDishInventory { get; set; }

    public Dish()
    {

    }

    public Dish(string name, decimal price, string dishDescription, Guid restaurantId, Guid? categoryId, Guid dishGeneralId)
    {
        DishName = name;
        Price = price;
        DishDescription = dishDescription;
        CategoryId = categoryId;
        Status = Status.Active;
        RestaurantId = restaurantId;
        DishGeneralId = dishGeneralId;
    }

    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }

    public void Update(string name, string description)
    {
        DishName = name;
        DishDescription = description;
    }
}
