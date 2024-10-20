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
                await AddRefundProductInventory(productId, _claimService.RestaurantId, productGeneral.DishGeneralImages.Select(x => x.Url).ToList());
            }
            else
            {
                var product = new Dish(productGeneral.Price, _claimService.RestaurantId, productGeneral.CategoryId, productGeneral.Id);
                await _unitOfWorks.DishRepository.AddAsync(product);
                await AddIngredientsToProduct(product.Id, productId);
            }
        }

        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok();
    }

    private async Task AddRefundProductInventory(Guid refundProduct, Guid restaurantId, List<string> Images)
    {
        DishGeneral dish = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(refundProduct)
                           ?? throw new Exception($"Dish with ID {refundProduct} not found.");
        if (dish.IsRefund)
        {
            Dish productAdding = new(dish.Price, restaurantId, dish.CategoryId, dish.Id);
            await _unitOfWorks.DishRepository.AddAsync(productAdding);
            RefundDishInventory inventory = new(productAdding.Id);
            await _unitOfWorks.RefundDishInventoryRepository.AddAsync(inventory);
        }
    }

    private async Task AddIngredientsToProduct(Guid productId, Guid dishGeneralId)
    {
        var ingredients = await _unitOfWorks.IngredientGeneralRepository
            .WhereAsync(x => x.DishIngredientGenerals.Any(pig => pig.DishGeneralId == dishGeneralId), x => x.DishIngredientGenerals);

        var ingredientNames = ingredients.Select(i => i.Id).ToList();
        var existingIngredients = await _unitOfWorks.IngredientRepository
            .WhereAsync(x => ingredientNames.Contains(x.IngredientGeneralId) && x.RestaurantId == _claimService.RestaurantId);

        foreach (var item in ingredients)
        {
            var existingIngredient = existingIngredients.FirstOrDefault(e => e.IngredientGeneralId == item.Id);
            IngredientGeneral? ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository.FirstOrDefaultAsync(x => x.IngredientName == item.IngredientName, x => x.DishIngredientGenerals);
            if (existingIngredient is null)
            {
                var newIngredient = new Ingredient(item.IngredientTypeId, _claimService.RestaurantId,item.Id);
                await _unitOfWorks.IngredientRepository.AddAsync(newIngredient);
                await AddDishIngredientAndUnits(productId, newIngredient.Id, item.IngredientMeasure, item.DishIngredientGenerals.FirstOrDefault().Quantity);
            }
            else
            {
                await _unitOfWorks.DishIngredientRepository.AddAsync(new DishIngredient(productId, existingIngredient.Id, ingredientGeneral.DishIngredientGenerals.FirstOrDefault(x => x.DishGeneralId == dishGeneralId && x.IngredientGeneralId == ingredientGeneral.Id).Quantity));
            }
        }
        await _unitOfWorks.SaveChangeAsync();
    }

    private async Task AddDishIngredientAndUnits(Guid productId, Guid ingredientId, IngredientMeasure measure, decimal quantity)
    {
        await _unitOfWorks.DishIngredientRepository.AddAsync(new DishIngredient(productId, ingredientId, quantity));
        await AddDefaultIngredientUnit(ingredientId, measure);
    }

    private async Task AddDefaultIngredientUnit(Guid ingredientId, IngredientMeasure measure)
    {
        var smallUnit = new IngredientUnit(MeasureTransfer.ToSmallUnit(measure), ingredientId);
        await _unitOfWorks.IngredientUnitRepository.AddAsync(smallUnit);

        if (measure == IngredientMeasure.gam || measure == IngredientMeasure.ml)
        {
            var largeUnit = new IngredientUnit(MeasureTransfer.ToLargeUnit(measure), ingredientId, smallUnit.Id, 1000);
            await _unitOfWorks.IngredientUnitRepository.AddAsync(largeUnit);
        }
    }
}
