using MediatR;
using Microsoft.AspNetCore.Http;

namespace FOV.Application.Features.GroupChats.Commands.RemoveGroupChat;
public sealed record RemoveGroupChatCommand : IRequest<IResult>;
internal class RemoveGroupChatHandler : IRequestHandler<RemoveGroupChatCommand, IResult>
{
    public Task<IResult> Handle(RemoveGroupChatCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
