using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.Create;

public sealed record CreateProductGeneralCommand(string DishGeneralName, decimal DishGeneralPrice, string DishGeneralDescription, Guid CategoryId, bool IsPreparedDish, List<AddIngredientCommand> Ingredients, string DishGeneralImage,decimal PercentPriceDifference,List<string> AdditionalImages) : IRequest<Guid>;


public sealed record AddIngredientCommand(Guid IngredientId, decimal Quantity);

public class CreateDishGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateProductGeneralCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Guid> Handle(CreateProductGeneralCommand request, CancellationToken cancellationToken)
    {


        DishGeneral productGeneral = new(request.DishGeneralName, request.DishGeneralPrice, request.DishGeneralDescription, request.CategoryId, request.DishGeneralImage, false, request.IsPreparedDish,request.PercentPriceDifference);
        await _unitOfWorks.DishGeneralRepository.AddAsync(productGeneral);

        await AddImage(request.AdditionalImages, productGeneral.Id);
        if (request.IsPreparedDish) await AddIngredient(request.Ingredients, productGeneral.Id);
        await _unitOfWorks.SaveChangeAsync();
        return productGeneral.Id;
    }
    private async ValueTask AddImage(List<string> Images,Guid DishGeneralId)
    {

        await _unitOfWorks.DishGeneralImageRepository.AddRangeAsync(Images
            .Select(item => new DishGeneralImage(item, DishGeneralId))
            .ToList());
        // Update images in related branches (ensure this operation succeeds)
    }

    private async ValueTask AddIngredient(List<AddIngredientCommand> commands, Guid productId)
    {
        var productIngredientGenerals = commands
            .Select(command => new DishIngredientGeneral(productId, command.IngredientId, command.Quantity))
            .ToList();

        await _unitOfWorks.DishIngredientGeneralRepository.AddRangeAsync(productIngredientGenerals);
    }
}
