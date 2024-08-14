namespace FOV.Application.Common.Behaviours.Claim;
public interface IClaimService
{
    public string UserId { get; }

    public string UserRole { get; }

    public Guid RestaurantId { get; }
}
