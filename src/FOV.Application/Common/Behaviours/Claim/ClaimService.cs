using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace FOV.Application.Common.Behaviours.Claim;
public class ClaimService : IClaimService
{
    public ClaimService(IHttpContextAccessor httpContextAccessor)
    {
        var id = httpContextAccessor.HttpContext?.User?.FindFirstValue("UserId");
        UserId = string.IsNullOrEmpty(id) ? string.Empty : id;
        var role = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
        UserRole = string.IsNullOrEmpty(role) ? string.Empty : role;
        var restaurantId = httpContextAccessor.HttpContext?.User?.FindFirstValue("RestaurantId");
        RestaurantId = Guid.TryParse(restaurantId, out Guid res) ? RestaurantId = res : RestaurantId = Guid.Parse("3c9a2a1b-f4dc-4468-a89c-f6be8ca3b541");
    }

    public string UserId { get; }

    public string UserRole { get; }

    public Guid RestaurantId { get; }
}
