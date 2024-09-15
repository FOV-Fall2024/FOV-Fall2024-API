using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Authorize.Commands.ForgotPassword;

public sealed record ForgotPasswordCommand(string Email) : IRequest<string>;
public class ForgotPasswordHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ForgotPasswordCommand, string>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public Task<string> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
