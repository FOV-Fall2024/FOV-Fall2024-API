namespace FOV.Application.Common.Behaviours.Claim;
public interface IClaimService
{
    public Guid UserId { get; }

    public string UserRole { get; }

    public Guid RestaurantId { get; }
}
