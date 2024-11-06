using System.Security.Cryptography;
using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientSupplyRequestAggregator.Enum;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.UserAggregator;

namespace FOV.Domain.Entities.IngredientSupplyRequestAggregator;
public class IngredientSupplyRequest : BaseAuditableEntity
{
    public string RequestCode { get; set; } = string.Empty;
    public Guid RestaurantId { get; set; } 

    public Restaurant Restaurant { get; set; }

    public SupplyRequestType Type { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public virtual ICollection<IngredientSupplyRequestDetail> IngredientSupplyRequestDetails { get; set; }
    public IngredientSupplyRequest(Guid userId,Guid restaurantId)
    {
        RequestCode = GenerateShortRequestCode();
        UserId = userId;
        Type = SupplyRequestType.PENDING;
        RestaurantId = restaurantId;

    }
    public IngredientSupplyRequest()
    {

    }

    public void View() => Type = SupplyRequestType.SEEN;


    private string GenerateShortRequestCode()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var code = new char[5];
        using (var rng = RandomNumberGenerator.Create())
        {
            var randomBytes = new byte[5];
            rng.GetBytes(randomBytes);

            for (int i = 0; i < 5; i++)
            {
                code[i] = chars[randomBytes[i] % chars.Length];
            }
        }

        return new string(code);
    }

}
