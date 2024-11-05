using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Authorize.Queries.Profile;
public sealed record ViewProfileCommand : IRequest<ViewProfileResponse>;

public sealed record ViewProfileResponse(Guid UserId, string FullName);
internal class ViewProfileHandler(UserManager<User> userManager, IClaimService claimService) : IRequestHandler<ViewProfileCommand, ViewProfileResponse>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IClaimService _claimService = claimService;
    public async Task<ViewProfileResponse> Handle(ViewProfileCommand request, CancellationToken cancellationToken)
    {
        User response = await _userManager.FindByIdAsync(_claimService.UserId.ToString()) ?? throw new Exception();
        return new ViewProfileResponse(response.Id, response.FullName);
    }
}
