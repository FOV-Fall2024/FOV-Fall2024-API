using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.NewDishRecommendAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.NewRecommendDishes.Commands.AdjustRequest;

public sealed record AdjustRequestCommand(string Name, string Description, string Image) : IRequest<Result>
{
    [JsonIgnore]
    public Guid RecommendProductId { get; set; }
}

internal class AdjustRequestHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AdjustRequestCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(AdjustRequestCommand request, CancellationToken cancellationToken)
    {
        NewDishRecommend? newProductRecommend = await _unitOfWorks.NewProductRecommendRepository.GetByIdAsync(request.RecommendProductId);

        DishGeneral? productGeneral = await _unitOfWorks.ProductGeneralRepository.GetByIdAsync(newProductRecommend.DishGeneralId);

        productGeneral.Update(request.Name, request.Description, request.Image);
        _unitOfWorks.ProductGeneralRepository.Update(productGeneral);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
