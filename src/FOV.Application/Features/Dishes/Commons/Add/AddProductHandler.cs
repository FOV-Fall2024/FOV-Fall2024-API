using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientAggregator.Enums;
using FOV.Domain.Entities.IngredientGeneralAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Dishes.Commons.Add;

public sealed record AddProductCommand(Guid ProductId) : IRequest<Result>;


internal class AddProductHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<AddProductCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<Result> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        DishGeneral productGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(request.ProductId) ?? throw new Exception();
        Dish product = new(productGeneral.DishName, _claimService.RestaurantId, productGeneral.CategoryId
            , productGeneral.Id);
        await _unitOfWorks.DishRepository.AddAsync(product);
        await AddIngredient(request.ProductId);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }

    private async Task AddIngredient(Guid productId)
    {
        var ingredients = await _unitOfWorks.IngredientGeneralRepository.WhereAsync(x => x.DishIngredientGenerals.Any(pig => pig.DishGeneralId == productId));
        foreach (var item in ingredients)
        {

            if (_unitOfWorks.IngredientRepository.WhereAsync(x => x.IngredientName == item.IngredientName) is null)
            {
                Ingredient ingredient = new(item.IngredientName, item.IngredientTypeId, _claimService.RestaurantId);
                await _unitOfWorks.IngredientRepository.AddAsync(ingredient);
                await AddDefaultIngredientUnit(ingredient.Id, item.IngredientMeasure);
            }
        }
    }


    private async Task AddDefaultIngredientUnit(Guid ingredientId, IngredientMeasure minMeasure)
    {
        //Default IngredientUnit
        IngredientUnit ingredientUnit = new(MeasureTransfer.ToSmallUnit(minMeasure), ingredientId);
        await _unitOfWorks.IngredientUnitRepository.AddAsync(ingredientUnit);

        if (minMeasure == IngredientMeasure.g || minMeasure == IngredientMeasure.ml)
        {
            IngredientUnit ingredientUnit2 = new(MeasureTransfer.ToLargeUnit(minMeasure), ingredientId, ingredientUnit.Id, 1000);
            await _unitOfWorks.IngredientUnitRepository.AddAsync(ingredientUnit2);
        }

        await _unitOfWorks.SaveChangeAsync();

    }
}
