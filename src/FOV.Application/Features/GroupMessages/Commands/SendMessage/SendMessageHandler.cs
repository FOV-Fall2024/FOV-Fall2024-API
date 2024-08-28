using System.Text.Json.Serialization;
using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.GroupChatAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FOV.Application.Features.GroupMessages.Commands.SendMessage;

public sealed record SendMessageCommand(string Content) : IRequest<Result>
{
    [JsonIgnore]
    public Guid GroupId { get; set; }
};

internal class SendMessageHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<SendMessageCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<Result> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        GroupMessage groupMessage = new(request.Content, _claimService.UserId, request.GroupId);
        await _unitOfWorks.GroupMessageRepository.AddAsync(groupMessage);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
        //? make group chat follow for any this RestaurantCode and Ca and Day 
        // 1 -2
        //? RestaurantCode_1_12022024


    }


}
