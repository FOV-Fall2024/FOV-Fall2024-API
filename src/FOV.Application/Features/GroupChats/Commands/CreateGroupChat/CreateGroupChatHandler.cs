using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FOV.Application.Features.GroupChats.Commands.CreateGroupChat;
public sealed record CreateGroupChatCommand : IRequest<IResult>;
internal class CreateGroupChatHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateGroupChatCommand, IResult>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public Task<IResult> Handle(CreateGroupChatCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
