using System.Text.Json.Serialization;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientAggregator.Enums;
using FOV.Domain.Entities.IngredientGeneralAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.AddIngredient;

public sealed record AddIngredientInProductCommand : IRequest<Guid>
{
    [JsonIgnore] public Guid Id { get; set; }

    public List<IngredientAddCommand> IngredientAdds { get; set; } = [];
}

public sealed record IngredientAddCommand(Guid IngredientId,decimal Quantity);
public class AddIngredientHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AddIngredientInProductCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Guid> Handle(AddIngredientInProductCommand request, CancellationToken cancellationToken)
    {
        foreach (var ingredient in request.IngredientAdds)
        {
           // var ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository
           //.GetByIdAsync(ingredient.IngredientId) ?? throw new Exception("Ingredient not found");

            var dishIngredientGeneral = new DishIngredientGeneral(request.Id, ingredient.IngredientId, ingredient.Quantity);
            await _unitOfWorks.DishIngredientGeneralRepository.AddAsync(dishIngredientGeneral);
          //  await UpdateDishesWithIngredient(request.Id, ingredientGeneral.IngredientName, ingredient.Quantity);
        }
       
        await _unitOfWorks.SaveChangeAsync();

        return request.Id;
    }

    //private async Task UpdateDishesWithIngredient(Guid dishGeneralId, string ingredientName, decimal quantity)
    //{
    //    var dishes = await _unitOfWorks.DishRepository.WhereAsync(d => d.DishGeneralId == dishGeneralId);

    //    foreach (var dish in dishes)
    //    {
    //        var ingredient = await _unitOfWorks.IngredientRepository
    //            .FirstOrDefaultAsync(i => i.IngredientGeneral.IngredientName == ingredientName && i.RestaurantId == dish.RestaurantId);

    //        ingredient ??= await AddIngredientToDish(ingredientName, dish.RestaurantId, dish.Id, dishGeneralId);

    //        await AddDishIngredient(dish.Id, ingredient.Id, ingredientName, dishGeneralId, quantity);
    //    }
    //}

    //private async Task<Ingredient> AddIngredientToDish(string ingredientName, Guid restaurantId, Guid dishId, Guid dishGeneralId)
    //{
    //    var ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository
    //        .FirstOrDefaultAsync(i => i.IngredientName == ingredientName,x => x.IngredientMeasure) ?? throw new Exception("Ingredient General not found");

    //    var newIngredient = new Ingredient(ingredientGeneral.IngredientName, ingredientGeneral.IngredientTypeId, restaurantId, ingredientGeneral.Id, ingredientGeneral.IngredientMeasureId);
    //    await _unitOfWorks.IngredientRepository.AddAsync(newIngredient);
    //    await AddDefaultIngredientUnit(newIngredient.Id, ingredientGeneral.IngredientMeasure.IngredientMeasureName);

    //    return newIngredient;
    //}

    //private async Task AddDishIngredient(Guid dishId, Guid ingredientId, string ingredientName, Guid dishGeneralId, decimal quantity)
    //{
    //    var dishIngredient = new DishIngredient(dishId, ingredientId, quantity);
    //    await _unitOfWorks.DishIngredientRepository.AddAsync(dishIngredient);
    //    await _unitOfWorks.SaveChangeAsync();
    //}

    //private async Task AddDefaultIngredientUnit(Guid ingredientId, string measure)
    //{
    //    var baseUnit = new IngredientUnit(MeasureTransfer.ToSmallUnit(measure), ingredientId);
    //    await _unitOfWorks.IngredientUnitRepository.AddAsync(baseUnit);

    //    if (measure == IngredientMeasureType.gam || measure == IngredientMeasureType.ml)
    //    {
    //        var largerUnit = new IngredientUnit(MeasureTransfer.ToLargeUnit(measure), ingredientId, baseUnit.Id, 1000);
    //        await _unitOfWorks.IngredientUnitRepository.AddAsync(largerUnit);
    //    }
    //}
}
