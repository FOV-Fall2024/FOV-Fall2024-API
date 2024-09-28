using System.Text.Json.Serialization;
using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.NewDishRecommendAggregator;
using FOV.Domain.Entities.NewDishRecommendAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.NewRecommendDishes.Commands.DenyResponse;

public sealed record DenyResponseCommand(string Note) : IRequest<Result>
{
    [JsonIgnore]
    public Guid NewProductRecommendId { get; set; }
}
internal class DenyResponseHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<DenyResponseCommand, Result>
{
    private readonly IClaimService _claimService = claimService;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(DenyResponseCommand request, CancellationToken cancellationToken)
    {
        NewDishRecommend productRecommend = await _unitOfWorks.NewDishRecommendRepository.GetByIdAsync(request.NewProductRecommendId) ?? throw new Exception();
        productRecommend.UpdateState(NewProductRecommendStatus.Denied);

        NewDishRecommendLog recommendLog = new(request.Note, productRecommend.Id, LogType.Response, _claimService.UserId);
        await _unitOfWorks.NewDishRecommendLogRepository.AddAsync(recommendLog);
        _unitOfWorks.NewDishRecommendRepository.Update(productRecommend);

        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
