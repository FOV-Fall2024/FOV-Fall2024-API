using System.Text.Json.Serialization;
using FluentResults;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.UpdateIngredientQuantity;

public sealed record UpdateIngredientQuantityCommand : IRequest<Result>
{
    [JsonIgnore] public Guid DishGeneralId { get; set; }

    public List<UpdateIngredientCommand> UpdateIngredient { get; set; }
}

public sealed record UpdateIngredientCommand(Guid IngredientGeneralId, decimal Quantity);

public class UpdateIngredientQuantityHandler : IRequestHandler<UpdateIngredientQuantityCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public UpdateIngredientQuantityHandler(IUnitOfWorks unitOfWorks) => _unitOfWorks = unitOfWorks;

    public async Task<Result> Handle(UpdateIngredientQuantityCommand request, CancellationToken cancellationToken)
    {
        try
        {
            foreach (var ingredient in request.UpdateIngredient)
            {
                var general = await _unitOfWorks.DishIngredientGeneralRepository
               .FirstOrDefaultAsync(x => x.IngredientGeneralId == ingredient.IngredientGeneralId && x.DishGeneralId == request.DishGeneralId)
               ?? throw new InvalidOperationException("Dish ingredient general not found");

                var ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository
                    .GetByIdAsync(ingredient.IngredientGeneralId)
                    ?? throw new InvalidOperationException("Ingredient not found");

                general.UpdateQuantity(ingredient.Quantity);
                _unitOfWorks.DishIngredientGeneralRepository.Update(general);

            }

            await _unitOfWorks.SaveChangeAsync();

            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail(new Error(ex.Message));
        }
    }
}
