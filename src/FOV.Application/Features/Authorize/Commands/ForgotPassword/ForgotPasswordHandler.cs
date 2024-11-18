using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Authorize.Commands.ForgotPassword;

public sealed record ForgotPasswordCommand(string PhoneNumber) : IRequest<string>;
public class ForgotPasswordHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<ForgotPasswordCommand, string>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;
    public Task<string> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
