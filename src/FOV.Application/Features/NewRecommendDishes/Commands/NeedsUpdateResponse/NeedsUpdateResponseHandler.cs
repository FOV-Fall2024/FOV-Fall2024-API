using System.Text.Json.Serialization;
using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.NewDishRecommendAggregator;
using FOV.Domain.Entities.NewDishRecommendAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.NewRecommendProducts.Commands.NeedsUpdateResponse;


public sealed record NeedsUpdateResponseCommand(string Note) : IRequest<Result>
{
    [JsonIgnore]
    public Guid NewRecommendProductId { get; set; }
}

internal class NeedsUpdateResponseHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<NeedsUpdateResponseCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<Result> Handle(NeedsUpdateResponseCommand request, CancellationToken cancellationToken)
    {
        NewDishRecommend productRecommend = await _unitOfWorks.NewProductRecommendRepository.GetByIdAsync(request.NewRecommendProductId) ?? throw new Exception();
        productRecommend.UpdateState(NewProductRecommendStatus.NeedsUpdate);

        NewDishRecommendLog recommendLog = new(request.Note, productRecommend.Id, LogType.Response, _claimService.UserId);
        await _unitOfWorks.NewProductRecommendLogRepository.AddAsync(recommendLog);
        _unitOfWorks.NewProductRecommendRepository.Update(productRecommend);

        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
