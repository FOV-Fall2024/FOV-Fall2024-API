using FOV.Domain.Common;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.TableAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.Entities.RestaurantAggregator;

public class Restaurant : BaseAuditableEntity, IsSoftDeleted
{
    public string RestaurantName { get; set; }
    public string Address { get; set; }

    public Status Status { get; set; }
    public string RestaurantPhone { get; set; }
    //public long Latitude { get; set; }
    //public long Longitude { get; set; }
    public string RestaurantCode { get; set; }

    public DateTime? ReleaseDate { get; set; } = DateTime.UtcNow;


    public virtual ICollection<Ingredient> Ingredients { get; set; } = [];

    public virtual ICollection<Dish> Dishes { get; set; } = [];
    public virtual ICollection<Table> Tables { get; set; } = [];
    public virtual ICollection<Combo> Combos { get; set; } = [];


    public Restaurant()
    {

    }

    public Restaurant(string name, string address, string phone, string code)
    {
        RestaurantName = name;
        Address = address;
        RestaurantPhone = phone;
        RestaurantCode = code;
        Created = DateTime.UtcNow.AddHours(7);
        Status = Status.Inactive;
    }
    public void Update(string name, string address, string phone)
    {
        RestaurantName = name;
        Address = address;
        RestaurantPhone = phone;
        LastModified = DateTime.UtcNow.AddHours(7);
    }
    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }
}
