using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientAggregator.Enums;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Dishes.Commons.Add;

public sealed record AddProductCommand(List<Guid> ProductId) : IRequest<Result>;

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
        foreach (var productId in request.ProductId)
        {
            var productGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(productId, x => x.DishGeneralImages)
                                ?? throw new Exception($"Product with ID {productId} not found.");

            if (productGeneral.IsRefund)
            {
                await AddRefundProductInventory(productId, _claimService.RestaurantId);
            }
            else
            {
                var product = new Dish(productGeneral.Price, _claimService.RestaurantId, productGeneral.CategoryId, productGeneral.Id,Domain.Entities.TableAggregator.Enums.Status.Active);
                await _unitOfWorks.DishRepository.AddAsync(product);
                await AddIngredientsToProduct(product.Id, productId);
            }
        }

        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok();
    }

    private async Task AddRefundProductInventory(Guid refundProduct, Guid restaurantId)
    {
        DishGeneral dish = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(refundProduct)
                           ?? throw new Exception($"Dish with ID {refundProduct} not found.");
        if (dish.IsRefund)
        {
            Dish productAdding = new(dish.Price, restaurantId, dish.CategoryId, dish.Id,Domain.Entities.TableAggregator.Enums.Status.New);
            await _unitOfWorks.DishRepository.AddAsync(productAdding);
            RefundDishInventory inventory = new(productAdding.Id);
            await _unitOfWorks.RefundDishInventoryRepository.AddAsync(inventory);
        }
    }

    private async Task AddIngredientsToProduct(Guid productId, Guid dishGeneralId)
    {
        // Retrieve all ingredients linked to the specified DishGeneral
        var ingredients = await _unitOfWorks.IngredientGeneralRepository
            .WhereAsync(
                x => x.DishIngredientGenerals.Any(dig => dig.DishGeneralId == dishGeneralId),
                x => x.DishIngredientGenerals
            );

        // Get names of the ingredients to check existing ones
        var ingredientNames = ingredients.Select(i => i.IngredientName).ToList();

        // Fetch existing ingredients in the current restaurant
        var existingIngredients = await _unitOfWorks.IngredientRepository
            .WhereAsync(x => ingredientNames.Contains(x.IngredientGeneral.IngredientName) && x.RestaurantId == _claimService.RestaurantId,x => x.IngredientGeneral);

        // Iterate through ingredients and process each
        foreach (var ingredient in ingredients)
        {
            await ProcessIngredient(ingredient, existingIngredients, productId, dishGeneralId);
        }

        // Save all changes
        await _unitOfWorks.SaveChangeAsync();
    }

    private async Task ProcessIngredient(IngredientGeneral ingredient, IEnumerable<Ingredient> existingIngredients, Guid productId, Guid dishGeneralId)
    {
        var existingIngredient = existingIngredients.FirstOrDefault(e => e.IngredientGeneral.IngredientName == ingredient.IngredientName);

        var ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository.FirstOrDefaultAsync(
            x => x.IngredientName == ingredient.IngredientName,
            x => x.DishIngredientGenerals,
            x => x.IngredientMeasure
        );

        if (ingredientGeneral == null)
        {
            throw new InvalidOperationException($"IngredientGeneral not found for ingredient: {ingredient.IngredientName}");
        }

        var dishIngredientGeneral = ingredientGeneral.DishIngredientGenerals?
            .FirstOrDefault(x => x.DishGeneralId == dishGeneralId && x.IngredientGeneralId == ingredientGeneral.Id);

        var quantity = dishIngredientGeneral?.Quantity ?? 0;

        if (existingIngredient == null)
        {
            var newIngredient = new Ingredient(ingredient.IngredientTypeId, _claimService.RestaurantId, ingredientGeneral.Id);
            await _unitOfWorks.IngredientRepository.AddAsync(newIngredient);

            await AddDishIngredientAndUnits(productId, newIngredient.Id, ingredient.IngredientMeasureId, quantity);
        }
        else
        {
            var dishIngredient = new DishIngredient(productId, existingIngredient.Id, quantity);
            await _unitOfWorks.DishIngredientRepository.AddAsync(dishIngredient);
        }
    }



    private async Task AddDishIngredientAndUnits(Guid productId, Guid ingredientId, Guid ingredientMeasureId, decimal quantity)
    {
        IngredientMeasure ingredientMeasure = await _unitOfWorks.IngredientMeasureRepository.GetByIdAsync(ingredientMeasureId) ?? throw new Exception();
        await _unitOfWorks.DishIngredientRepository.AddAsync(new DishIngredient(productId, ingredientId, quantity));
        await AddDefaultIngredientUnit(ingredientId, ingredientMeasure.IngredientMeasureName);
    }

    private async Task AddDefaultIngredientUnit(Guid ingredientId, string ingredientMeasureName)
    {
        var smallUnit = new IngredientUnit(ingredientMeasureName, ingredientId);
        await _unitOfWorks.IngredientUnitRepository.AddAsync(smallUnit);

        if (ingredientMeasureName == IngredientMeasureType.gam || ingredientMeasureName == IngredientMeasureType.ml)
        {
            var largeUnit = new IngredientUnit(MeasureTransfer.ToLargeUnit(ingredientMeasureName), ingredientId, smallUnit.Id, 1000);
            await _unitOfWorks.IngredientUnitRepository.AddAsync(largeUnit);
        }
    }
}
