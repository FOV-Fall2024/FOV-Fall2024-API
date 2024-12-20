﻿using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Authorize.Commands.EditProfile;

public sealed record EditProfileCommand : IRequest<Guid>
{
    public string PhoneNumber { get; set; }
    public string FullName { get; set; }
};
public class EditProfileHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager, IClaimService claimService) : IRequestHandler<EditProfileCommand, Guid>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<Guid> Handle(EditProfileCommand request, CancellationToken cancellationToken)
    {
        Guid userId = _claimService.UserId;
        User user = await _userManager.FindByIdAsync(userId.ToString()) ?? throw new AppException("Không tìm thấy ID của Employee này");
        user.Update(request.PhoneNumber, request.FullName);
        await _userManager.UpdateAsync(user);

        await _unitOfWorks.SaveChangeAsync();
        return user.Id;
    }
}
