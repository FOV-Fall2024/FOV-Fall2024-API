using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.Create;

public sealed record CreateProductGeneralCommand(string DishGeneralName, decimal DishGeneralPrice, string DishGeneralDescription, Guid CategoryId, bool IsRefund, List<AddIngredientCommand> Ingredients, decimal PercentPriceDifference,List<string> Images) : IRequest<Guid>;


public sealed record AddIngredientCommand(Guid IngredientId, decimal Quantity);

public class CreateDishGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateProductGeneralCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Guid> Handle(CreateProductGeneralCommand request, CancellationToken cancellationToken)
    {


        DishGeneral productGeneral = new(request.DishGeneralName, request.DishGeneralPrice, request.DishGeneralDescription, request.CategoryId, false, request.IsRefund, request.PercentPriceDifference);
        await _unitOfWorks.DishGeneralRepository.AddAsync(productGeneral);

        await AddImage(request.Images, productGeneral.Id);
        if (!request.IsRefund) await AddIngredient(request.Ingredients, productGeneral.Id); //????
        await _unitOfWorks.SaveChangeAsync();
        return productGeneral.Id;
    }
    private async ValueTask AddImage(List<string> images, Guid dishGeneralId)
    {
        // Ensure you are passing the 'Order' parameter when creating each DishGeneralImage
        var dishImages = images.Select((item, index) => new DishGeneralImage(item, dishGeneralId, index + 1)).ToList();

        await _unitOfWorks.DishGeneralImageRepository.AddRangeAsync(dishImages);
    }


    private async ValueTask AddIngredient(List<AddIngredientCommand> commands, Guid productId)
    {
        var productIngredientGenerals = commands
            .Select(command => new DishIngredientGeneral(productId, command.IngredientId, command.Quantity))
            .ToList();

        await _unitOfWorks.DishIngredientGeneralRepository.AddRangeAsync(productIngredientGenerals);
    }
}
