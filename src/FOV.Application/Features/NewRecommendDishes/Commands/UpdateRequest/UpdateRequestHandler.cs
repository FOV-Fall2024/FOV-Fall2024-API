using System.Text.Json.Serialization;
using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.NewDishRecommendAggregator;
using FOV.Domain.Entities.NewDishRecommendAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.NewRecommendDishes.Commands.UpdateRequest;

public sealed record UpdateRequestCommand(string Name, string Description, Guid CategoryId, string Image, string Note) : IRequest<Result>
{
    [JsonIgnore]
    public Guid NewRecommendProductId { get; set; }


}
internal class UpdateRequestHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<UpdateRequestCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<Result> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
    {
        NewDishRecommend productRecommend = await _unitOfWorks.NewProductRecommendRepository.GetByIdAsync(request.NewRecommendProductId) ?? throw new Exception();
        productRecommend.UpdateState(NewProductRecommendStatus.Pending);

        NewDishRecommendLog recommendLog = new(request.Note, productRecommend.Id, LogType.Request, _claimService.UserId);
        await _unitOfWorks.NewProductRecommendLogRepository.AddAsync(recommendLog);

        DishGeneral productGeneral = await _unitOfWorks.ProductGeneralRepository.GetByIdAsync(productRecommend.DishGeneralId) ?? throw new Exception();
        productGeneral.Update(request.Name, request.Description, request.Image, request.CategoryId);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();



    }
}
