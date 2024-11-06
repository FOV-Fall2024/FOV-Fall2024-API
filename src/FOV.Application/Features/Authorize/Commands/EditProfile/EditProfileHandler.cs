using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Authorize.Commands.EditProfile;

public sealed record EditProfileCommand : IRequest<Result>
{
    public string PhoneNumber { get; set; }
    public string FullName { get; set; }
};
public class EditProfileHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager, IClaimService claimService) : IRequestHandler<EditProfileCommand, Result>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<Result> Handle(EditProfileCommand request, CancellationToken cancellationToken)
    {
        Guid userId = _claimService.UserId;
        User user = await _userManager.FindByIdAsync(userId.ToString()) ?? throw new Exception();
        user.Update(request.FullName, request.PhoneNumber);
        Customer customer = await _unitOfWorks.CustomerRepository.FirstOrDefaultAsync(x => x.Id == userId) ?? throw new Exception();
        customer.Update(request.FullName, request.PhoneNumber);
        _unitOfWorks.CustomerRepository.Update(customer);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
