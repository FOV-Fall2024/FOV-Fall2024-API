using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.UpdateIngredientQuantity;

public sealed record UpdateIngredientQuantityCommand : IRequest<Result>
{
    [JsonIgnore] public Guid DishGeneralId { get; set; }
    [JsonIgnore] public Guid IngredientGeneralId { get; set; }
    public decimal Quantity { get; set; }
}

public class UpdateIngredientQuantityHandler : IRequestHandler<UpdateIngredientQuantityCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public UpdateIngredientQuantityHandler(IUnitOfWorks unitOfWorks) => _unitOfWorks = unitOfWorks;

    public async Task<Result> Handle(UpdateIngredientQuantityCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var general = await _unitOfWorks.DishIngredientGeneralRepository
                .FirstOrDefaultAsync(x => x.IngredientGeneralId == request.IngredientGeneralId && x.DishGeneralId == request.DishGeneralId)
                ?? throw new InvalidOperationException("Dish ingredient general not found");

            var ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository
                .GetByIdAsync(request.IngredientGeneralId)
                ?? throw new InvalidOperationException("Ingredient not found");

            general.Update(request.DishGeneralId, request.IngredientGeneralId, request.Quantity);
            _unitOfWorks.DishIngredientGeneralRepository.Update(general);

            await UpdateDishesWithIngredient(general.Id, ingredientGeneral.IngredientName);
            await _unitOfWorks.SaveChangeAsync();

            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail(new Error(ex.Message));
        }
    }

    private async Task UpdateDishesWithIngredient(Guid dishGeneralId, string ingredientName)
    {
        var dishes = await _unitOfWorks.DishRepository.WhereAsync(d => d.DishGeneralId == dishGeneralId);

        foreach (var dish in dishes)
        {
            var ingredient = await _unitOfWorks.IngredientRepository
                .FirstOrDefaultAsync(i => i.IngredientName == ingredientName && i.RestaurantId == dish.RestaurantId)
                ?? throw new InvalidOperationException("Ingredient not found in the restaurant");

            await UpdateDishIngredient(dish.Id, ingredient.Id);
        }
    }

    private async Task UpdateDishIngredient(Guid dishId, Guid ingredientId)
    {
        var dishIngredient = await _unitOfWorks.DishIngredientRepository
            .FirstOrDefaultAsync(x => x.IngredientId == ingredientId && x.DishId == dishId)
            ?? throw new InvalidOperationException("Dish ingredient not found");

        dishIngredient.ChangeState(Domain.Entities.DishAggregator.Enums.DishIngredientStatus.UpdateQuantity);
        _unitOfWorks.DishIngredientRepository.Update(dishIngredient);

        await _unitOfWorks.SaveChangeAsync();
    }
}
