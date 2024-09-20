using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.NewProductRecommendAggregator;
using FOV.Domain.Entities.NewProductRecommendAggregator.Enums;
using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.NewRecommendProducts.Commands.NewRequest;

public sealed record NewRequestCommand : IRequest<Guid>
{
    public required string ProductName { get; set; }

    public required string ProductDescription { get; set; }

    public required Guid CategoryId { get; set; }

    public required string ProductImage { get; set; }
    public string Note { get; set; } = string.Empty;


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
        ProductGeneral productGeneral = new(request.ProductName, request.ProductDescription, request.CategoryId, request.ProductImage, true);
        await _unitOfWorks.ProductGeneralRepository.AddAsync(productGeneral);

        await AddIngredient(request.Ingredients, productGeneral.Id);

        NewProductRecommend newRecommend = new(_claimService.RestaurantId, productGeneral.Id, NewProductRecommendStatus.Pending);
        await _unitOfWorks.NewProductRecommendRepository.AddAsync(newRecommend);
        Console.WriteLine(newRecommend.Id);
        //error at this
        NewProductRecommendLog recommendLog = new(request.Note, newRecommend.Id, LogType.Request, _claimService.UserId);
        await _unitOfWorks.NewProductRecommendLogRepository.AddAsync(recommendLog);

        await _unitOfWorks.SaveChangeAsync();
        return newRecommend.Id;
        //? Create New Request
        //? Check Log
    }
    private async ValueTask AddIngredient(List<IngredientInRequestCommand> commands, Guid productId)
    {
        var productIngredientGenerals = commands
            .Select(command => new ProductIngredientGeneral(productId, command.IngredientId, command.Quantity))
            .ToList();

        await _unitOfWorks.ProductIngredientGeneralRepository.AddRangeAsync(productIngredientGenerals);
    }


}
