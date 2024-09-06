using FluentResults;
using FOV.Domain.Entities.GroupChatAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.GroupChats.Commands.CreateGroupChat;
public sealed record CreateGroupChatCommand(Guid RestaurantId) : IRequest<Result>;
internal class CreateGroupChatHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateGroupChatCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Result> Handle(CreateGroupChatCommand request, CancellationToken cancellationToken)
    {
        var groupChat = new GroupChat
        {
            GroupName = "My Group Name",
            RestaurantId = request.RestaurantId,
        };
        await _unitOfWorks.GroupChatRepository.AddAsync(groupChat);
        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok();


    }
}
