using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.Helpers.FirebaseHandler;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FOV.Application.Features.DishGenerals.Commands.Create;

public sealed record CreateProductGeneralCommand(string ProductName, string Description, Guid CategoryId, List<AddIngredientCommand> Ingredients, string ImageDefault) : IRequest<Guid>;
//{
//    public required string ProductName { get; set; }
//    public required string Description { get; set; }
//    public required Guid CategoryId { get; set; }
//    public required List<AddIngredientCommand> Ingredients { get; set; } = new List<AddIngredientCommand>();
//    public required string ImageDefault { get; set; }
//}

public sealed record AddIngredientCommand(Guid IngredientId, decimal Quantity);

public class CreateDishGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateProductGeneralCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Guid> Handle(CreateProductGeneralCommand request, CancellationToken cancellationToken)
    {


        DishGeneral productGeneral = new(request.ProductName, request.Description, request.CategoryId, request.ImageDefault, false);
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
