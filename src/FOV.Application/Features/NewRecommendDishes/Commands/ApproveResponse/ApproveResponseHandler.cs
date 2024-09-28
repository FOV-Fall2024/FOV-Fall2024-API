using System.Text.Json.Serialization;
using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.NewDishRecommendAggregator;
using FOV.Domain.Entities.NewDishRecommendAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.NewRecommendDishes.Commands.ApproveResponse;

public sealed record ApproveResponseCommand(string Note) : IRequest<Result>
{
    [JsonIgnore]
    public Guid NewProductRecommendId { get; set; }
}
public class ApproveResponseHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<ApproveResponseCommand, Result>
{
    private readonly IClaimService _claimService = claimService;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Result> Handle(ApproveResponseCommand request, CancellationToken cancellationToken)
    {
        NewDishRecommend productRecommend = await _unitOfWorks.NewProductRecommendRepository.GetByIdAsync(request.NewProductRecommendId) ?? throw new Exception();
        productRecommend.UpdateState(NewProductRecommendStatus.Approved);

        NewDishRecommendLog recommendLog = new(request.Note, productRecommend.Id, LogType.Response, _claimService.UserId);
        await _unitOfWorks.NewProductRecommendLogRepository.AddAsync(recommendLog);
        _unitOfWorks.NewProductRecommendRepository.Update(productRecommend);
        DishGeneral productGeneral = await _unitOfWorks.ProductGeneralRepository.GetByIdAsync(productRecommend.DishGeneralId) ?? throw new Exception();
        productGeneral.SetDraftState(false);
        _unitOfWorks.ProductGeneralRepository.Update(productGeneral);

        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();



    }
}
