using FOV.Domain.Common;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;


namespace FOV.Domain.Entities.DishGeneralAggregator;

public class DishGeneral : BaseAuditableEntity, IsSoftDeleted
{
    public string DishName { get; set; } = string.Empty;
    public string DishDescription { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string DishImageDefault { get; set; } = string.Empty;
    public virtual ICollection<Dish> Dishes { get; set; } = [];
    public decimal PercentagePriceDifference { get; set; } = 0;
    public Category Category { get; set; }
    public Guid? CategoryId { get; set; }
    public bool IsRefund { get; set; }
    public Guid? DishGeneralParentId { get; set; }
    public DishGeneral? DishGeneralParent { get; set; }
    public virtual ICollection<DishGeneral> ChildDishGenerals { get; set; } = new List<DishGeneral>();

    public virtual ICollection<DishIngredientGeneral> Ingredients { get; set; } = [];
    public Status Status { get; set; }

    public ICollection<DishGeneralImage> DishGeneralImages { get; set; } = [];
    public DishGeneral()
    {

    }

    public DishGeneral(string name, decimal price, string description, Guid categoryId, bool isRefund, decimal percentagePriceDifference)
    {
        DishName = name;
        Price = price;
        DishDescription = description;
        Status = Status.New;
        CategoryId = categoryId;
        Id = Guid.NewGuid();
        IsRefund = isRefund;
        PercentagePriceDifference = percentagePriceDifference;
    }
    public DishGeneral(string name, decimal price, string description, Guid? categoryId, bool isRefund, decimal percentagePriceDifference,Guid parentId)
    {
        DishGeneralParentId = parentId;
        DishName = name;
        Price = price;
        DishDescription = description;
        Status = Status.New;
        CategoryId = categoryId;
        Id = Guid.NewGuid();
        IsRefund = isRefund;
        PercentagePriceDifference = percentagePriceDifference;
    }


    public void Update(string name, string description, Guid categoryId)
    {
        DishName = name;
        DishDescription = description;
        CategoryId = categoryId;
    }

    public void Update(string name, string description, string image)
    {
        DishName = name;
        DishDescription = description;
        DishImageDefault = image;
    }

    public void Update(string name, string description, string image, Guid categoryId)
    {
        DishName = name;
        DishDescription = description;
        DishImageDefault = image;
        CategoryId = categoryId;
    }
    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }
}
