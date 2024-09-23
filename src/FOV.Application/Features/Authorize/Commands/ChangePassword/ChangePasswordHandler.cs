using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.UserAggregator;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Authorize.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<Result>
    {
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    internal class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, Result>
    {
        private readonly IClaimService _claimService;
        private readonly UserManager<User> _userManager;

        public ChangePasswordHandler(IClaimService claimService, UserManager<User> userManager)
        {
            _claimService = claimService;
            _userManager = userManager;
        }

        public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            // Validate that the new password and confirm password match
            if (request.NewPassword != request.ConfirmPassword)
            {
                return Result.Fail("Mật khẩu mới và xác nhận mật khẩu chưa trùng nhau");
            }

            // Find the user by ID
            User? user = await _userManager.FindByIdAsync(_claimService.UserId);
            if (user == null)
            {
                return Result.Fail("Không tìm thấy người dùng");
            }

            // Attempt to change the password
            var changePasswordResult = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
            if (changePasswordResult.Succeeded)
            {
                return Result.Ok();
            }

            // Handle failure to change password and return errors
            var errors = changePasswordResult.Errors.Select(e => e.Description).ToList();
            return Result.Fail(errors);
        }
    }
}
