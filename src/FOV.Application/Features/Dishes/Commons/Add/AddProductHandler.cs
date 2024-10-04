﻿using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientAggregator.Enums;
using FOV.Domain.Entities.IngredientGeneralAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Dishes.Commons.Add;

public sealed record AddProductCommand(Guid ProductId) : IRequest<Result>;

internal class AddProductHandler : IRequestHandler<AddProductCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IClaimService _claimService;

    public AddProductHandler(IUnitOfWorks unitOfWorks, IClaimService claimService)
    {
        _unitOfWorks = unitOfWorks;
        _claimService = claimService;
    }

    public async Task<Result> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var productGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(request.ProductId) ?? throw new Exception("Product not found");

        var product = new Dish(productGeneral.DishName, productGeneral.Price, _claimService.RestaurantId, productGeneral.CategoryId, productGeneral.Id);
        await _unitOfWorks.DishRepository.AddAsync(product);

        await AddIngredientsToProduct(product.Id);
        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok();
    }

    private async Task AddIngredientsToProduct(Guid productId)
    {
        var ingredients = await _unitOfWorks.IngredientGeneralRepository
            .WhereAsync(x => x.DishIngredientGenerals.Any(pig => pig.DishGeneralId == productId));

        var ingredientNames = ingredients.Select(i => i.IngredientName).ToList();
        var existingIngredients = await _unitOfWorks.IngredientRepository
            .WhereAsync(x => ingredientNames.Contains(x.IngredientName) && x.RestaurantId == _claimService.RestaurantId);

        foreach (var item in ingredients)
        {
            var existingIngredient = existingIngredients.FirstOrDefault(e => e.IngredientName == item.IngredientName);

            if (existingIngredient is null)
            {
                var newIngredient = new Ingredient(item.IngredientName, item.IngredientTypeId, _claimService.RestaurantId);
                await _unitOfWorks.IngredientRepository.AddAsync(newIngredient);
                await AddDishIngredientAndUnits(productId, newIngredient.Id, item.IngredientMeasure);
            }
            else
            {
                await _unitOfWorks.DishIngredientRepository.AddAsync(new DishIngredient(productId, existingIngredient.Id));
            }

            await _unitOfWorks.SaveChangeAsync();
        }
    }

    private async Task AddDishIngredientAndUnits(Guid productId, Guid ingredientId, IngredientMeasure measure)
    {
        await _unitOfWorks.DishIngredientRepository.AddAsync(new DishIngredient(productId, ingredientId));
        await AddDefaultIngredientUnit(ingredientId, measure);
    }

    private async Task AddDefaultIngredientUnit(Guid ingredientId, IngredientMeasure measure)
    {
        var smallUnit = new IngredientUnit(MeasureTransfer.ToSmallUnit(measure), ingredientId);
        await _unitOfWorks.IngredientUnitRepository.AddAsync(smallUnit);

        if (measure == IngredientMeasure.g || measure == IngredientMeasure.ml)
        {
            var largeUnit = new IngredientUnit(MeasureTransfer.ToLargeUnit(measure), ingredientId, smallUnit.Id, 1000);
            await _unitOfWorks.IngredientUnitRepository.AddAsync(largeUnit);
        }
    }
}
