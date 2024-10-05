using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.NewDishRecommendAggregator;
using FOV.Domain.Entities.NewDishRecommendAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.NewRecommendDishes.Commands.NewRequest;

public sealed record NewRequestCommand : IRequest<Guid>
{
    public required string ProductName { get; set; }
    public required decimal Price { get; set; }
    public required string ProductDescription { get; set; }

    public required Guid CategoryId { get; set; }

    public required bool IsRefundDish { get; set; }

    public required string ProductImage { get; set; }
    public string Note { get; set; } = string.Empty;
    public decimal PercentPriceDifference { get; set; }

    public List<IngredientInRequestCommand> Ingredients { get; set; } = [];


}

public sealed record IngredientInRequestCommand(Guid IngredientId, decimal Quantity);

public class NewRequestHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<NewRequestCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<Guid> Handle(NewRequestCommand request, CancellationToken cancellationToken)
    {
        //? Create New Product
        DishGeneral productGeneral = new(request.ProductName, request.Price, request.ProductDescription, request.CategoryId, request.ProductImage, true, request.IsRefundDish,request.PercentPriceDifference);
        await _unitOfWorks.DishGeneralRepository.AddAsync(productGeneral);

        await AddIngredient(request.Ingredients, productGeneral.Id);

        NewDishRecommend newRecommend = new(_claimService.RestaurantId, productGeneral.Id, NewProductRecommendStatus.Pending);
        await _unitOfWorks.NewDishRecommendRepository.AddAsync(newRecommend);

        NewDishRecommendLog recommendLog = new(request.Note, newRecommend.Id, LogType.Request, _claimService.UserId);
        await _unitOfWorks.NewDishRecommendLogRepository.AddAsync(recommendLog);

        await _unitOfWorks.SaveChangeAsync();
        return newRecommend.Id;
        //? Create New Request
        //? Check Log
    }
    private async ValueTask AddIngredient(List<IngredientInRequestCommand> commands, Guid productId)
    {
        var productIngredientGenerals = commands
            .Select(command => new DishIngredientGeneral(productId, command.IngredientId, command.Quantity))
            .ToList();

        await _unitOfWorks.DishIngredientGeneralRepository.AddRangeAsync(productIngredientGenerals);
    }


}
