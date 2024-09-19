using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Infrastructure.Helpers.FirebaseHandler;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FOV.Application.Features.ProductGenerals.Commands.Create;

public sealed record CreateProductGeneralCommand : IRequest<Guid>
{
    public required string ProductName { get; set; }
    public required string Description { get; set; }
    public required Guid CategoryId { get; set; }
    public required List<AddIngredientCommand> Ingredients { get; set; }
    public required string ImageDefault { get; set; }
}

public sealed record AddIngredientCommand(Guid Ingredient, decimal Quantity);

public class CreateProductGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateProductGeneralCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Guid> Handle(CreateProductGeneralCommand request, CancellationToken cancellationToken)
    {
       

        ProductGeneral productGeneral = new(request.ProductName, request.Description, request.CategoryId, request.ImageDefault,false);
        await _unitOfWorks.ProductGeneralRepository.AddAsync(productGeneral);

        await AddIngredient(request.Ingredients, productGeneral.Id);
        await _unitOfWorks.SaveChangeAsync();
        return productGeneral.Id;
    }

    private async ValueTask AddIngredient(List<AddIngredientCommand> commands, Guid productId)
    {
        var productIngredientGenerals = commands
            .Select(command => new ProductIngredientGeneral(productId, command.Ingredient, command.Quantity))
            .ToList();

        await _unitOfWorks.ProductIngredientGeneralRepository.AddRangeAsync(productIngredientGenerals);
    }
}
