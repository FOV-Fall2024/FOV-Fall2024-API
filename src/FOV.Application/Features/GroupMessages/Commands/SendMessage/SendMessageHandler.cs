using System.Text.Json.Serialization;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FOV.Application.Features.GroupMessages.Commands.SendMessage;

public sealed record SendMessageCommand(string Message, string Content) : IRequest<IResult>
{
    [JsonIgnore]
    public Guid GroupId { get; set; }
};

internal class SendMessageHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<SendMessageCommand, IResult>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public Task<IResult> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        //? make group chat follow for any this RestaurantCode and Ca and Day 
        // 1 -2
        //? RestaurantCode_1_12022024

        throw new NotImplementedException();

    }


}
