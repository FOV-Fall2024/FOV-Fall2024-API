using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.Create;

public sealed record CreateProductGeneralCommand(string DishGeneralName, decimal DishGeneralPrice, string DishGeneralDescription, Guid CategoryId, bool IsPreparedDish, List<AddIngredientCommand> Ingredients, string DishGeneralImage) : IRequest<Guid>;


public sealed record AddIngredientCommand(Guid IngredientId, decimal Quantity);

public class CreateDishGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateProductGeneralCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Guid> Handle(CreateProductGeneralCommand request, CancellationToken cancellationToken)
    {


        DishGeneral productGeneral = new(request.DishGeneralName, request.DishGeneralPrice, request.DishGeneralDescription, request.CategoryId, request.DishGeneralImage, false, request.IsPreparedDish);
        await _unitOfWorks.DishGeneralRepository.AddAsync(productGeneral);

        await AddIngredient(request.Ingredients, productGeneral.Id);
        await _unitOfWorks.SaveChangeAsync();
        return productGeneral.Id;
    }

    private async ValueTask AddIngredient(List<AddIngredientCommand> commands, Guid productId)
    {
        var productIngredientGenerals = commands
            .Select(command => new DishIngredientGeneral(productId, command.IngredientId, command.Quantity))
            .ToList();

        await _unitOfWorks.DishIngredientGeneralRepository.AddRangeAsync(productIngredientGenerals);
    }
}
