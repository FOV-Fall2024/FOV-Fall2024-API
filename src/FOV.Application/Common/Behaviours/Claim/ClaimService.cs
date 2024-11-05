using System.Security.Claims;
using FOV.Domain.Entities.UserAggregator.Enums;
using Microsoft.AspNetCore.Http;

namespace FOV.Application.Common.Behaviours.Claim;
public class ClaimService : IClaimService
{
    public ClaimService(IHttpContextAccessor httpContextAccessor)
    {
        var id = httpContextAccessor.HttpContext?.User?.FindFirstValue("UserId");
        UserId = Guid.TryParse(id, out Guid user) ? UserId = user : UserId = Guid.Empty;
        var role = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
        UserRole = string.IsNullOrEmpty(role) ? Role.Administrator : role; //Change later
        var restaurantId = httpContextAccessor.HttpContext?.User?.FindFirstValue("RestaurantId");
        RestaurantId = Guid.TryParse(restaurantId, out Guid res) ? RestaurantId = res : RestaurantId = Guid.Parse("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0");
    }

    public Guid UserId { get; }

    public string UserRole { get; }

    public Guid RestaurantId { get; }
}
