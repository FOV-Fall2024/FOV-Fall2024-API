using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientAggregator.Enums;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator.Enums;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Restaurants.Commons.Create;

public sealed record CreateRestaurantCommand : IRequest<Guid>
{
    public required string RestaurantName { get; set; }

    public required string Address { get; set; }

    public required string RestaurantPhone { get; set; }

    public ICollection<Guid> Products { get; set; } = [];
}

internal class CreateRestaurantHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateRestaurantCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        #region Validate
        var fieldErrors = new List<FieldError>();

        bool existRestaurantName = await _unitOfWorks.RestaurantRepository.AnyAsync(r =>
            r.RestaurantName == request.RestaurantName);

        if (existRestaurantName)
        {
            fieldErrors.Add(new FieldError { Field = "restaurantName", Message = "Đã có nhà hàng trùng tên" });
        }

        bool existAddress = await _unitOfWorks.RestaurantRepository.AnyAsync(r =>
            r.Address == request.Address);

        if (existAddress)
        {
            fieldErrors.Add(new FieldError { Field = "address", Message = "Đã có nhà hàng trùng địa chỉ" });
        }

        bool existPhone = await _unitOfWorks.RestaurantRepository.AnyAsync(r =>
            r.RestaurantPhone == request.RestaurantPhone);

        if (existPhone)
        {
            fieldErrors.Add(new FieldError { Field = "restaurantPhone", Message = "Đã có nhà hàng trùng số điện thoại" });
        }

        if (fieldErrors.Any())
        {
            throw new AppException("Lỗi khi tạo nhà hàng mới", fieldErrors);
        }
        #endregion

        Restaurant restaurant = new(request.RestaurantName, request.Address, request.RestaurantPhone, await GeneratedCode());
        await _unitOfWorks.RestaurantRepository.AddAsync(restaurant);
        await AddNewProduct(request.Products, restaurant.Id);
        await AddRefundProductInventory(request.Products, restaurant.Id);
        await _unitOfWorks.SaveChangeAsync();

        return restaurant.Id;
    }

    private async Task AddRefundProductInventory(ICollection<Guid> refundProduct, Guid restaurantId)
    {

        foreach (var product in refundProduct)
        {
            DishGeneral dishGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(product)
                               ?? throw new Exception($"Dish with ID {product} not found.");
            if (dishGeneral.IsRefund)
            {
                Dish productAdding = new(dishGeneral.Price, restaurantId, dishGeneral.CategoryId, dishGeneral.Id);
                await _unitOfWorks.DishRepository.AddAsync(productAdding);
                RefundDishInventory inventory = new(productAdding.Id);
                await _unitOfWorks.RefundDishInventoryRepository.AddAsync(inventory);
                RefundDishUnit unit = new(inventory.Id);
                await _unitOfWorks.RefundDishUnitRepository.AddAsync(unit);
            }
        }

    }
    private async Task<string> GeneratedCode()
    {
        static string GenerateNewCode(int number)
        {
            return $"RE_{number:D3}";
        }

        string newCode;
        int codeNumber = 1;

        do
        {
            newCode = GenerateNewCode(codeNumber);
            codeNumber++;
        } while (await _unitOfWorks.RestaurantRepository.AnyAsync(r => r.RestaurantCode == newCode));

        return newCode;
    }


    private async Task AddNewProduct(ICollection<Guid> products, Guid restaurantId)
    {
        foreach (var product in products)
        {
            DishGeneral? productGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(product, x => x.Ingredients, x => x.DishGeneralImages);
            if (productGeneral is not null)
            {
                var ingredientGenerals = await _unitOfWorks.IngredientGeneralRepository.WhereAsync(x => x.DishIngredientGenerals.Any(pg => pg.DishGeneralId == productGeneral.Id));
                Dish productAdding = new(productGeneral.Price, restaurantId, productGeneral.CategoryId, productGeneral.Id);
                await _unitOfWorks.DishRepository.AddAsync(productAdding);
                await ProductIngredientAdd(ingredientGenerals.Select(x => x.IngredientName).ToList(), restaurantId, productAdding.Id, productGeneral.Id);
            }
        }
    }

    private async Task ProductIngredientAdd(ICollection<string> ingredientNames, Guid restaurantId, Guid productId, Guid productGeneralId)
    {
        foreach (var item in ingredientNames)
        {
            Ingredient? ingredient = _unitOfWorks.IngredientRepository.FirstOrDefaultAsync(x => x.IngredientName == item && x.RestaurantId == restaurantId).Result;
            if (ingredient == null)
            {
                IngredientGeneral ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository.FirstOrDefaultAsync(x => x.IngredientName == item, x => x.DishIngredientGenerals) ?? throw new Exception();
                Ingredient ingredient1 = new(ingredientGeneral.IngredientName, ingredientGeneral.IngredientTypeId, restaurantId);

                await _unitOfWorks.IngredientRepository.AddAsync(ingredient1);
                await _unitOfWorks.DishIngredientRepository.AddAsync(new DishIngredient(productId, ingredient1.Id, ingredientGeneral.DishIngredientGenerals.FirstOrDefault(x => x.DishGeneralId == productGeneralId && x.IngredientGeneralId == ingredientGeneral.Id).Quantity));
                await AddDefaultIngredientUnit(ingredient1.Id, ingredientGeneral.IngredientMeasure);
            }
        }


    }

    private async Task AddDefaultIngredientUnit(Guid ingredientId, IngredientMeasure minMeasure)
    {
        IngredientUnit ingredientUnit = new(MeasureTransfer.ToSmallUnit(minMeasure), ingredientId);

        if (ingredientUnit.IngredientUnitParentId == Guid.Empty)
        {
            ingredientUnit.IngredientUnitParentId = null;
        }

        await _unitOfWorks.IngredientUnitRepository.AddAsync(ingredientUnit);
        await _unitOfWorks.SaveChangeAsync();

        if (minMeasure == IngredientMeasure.gam || minMeasure == IngredientMeasure.ml)
        {
            IngredientUnit ingredientUnit2 = new(MeasureTransfer.ToLargeUnit(minMeasure), ingredientId, ingredientUnit.Id, 1000);

            if (ingredientUnit2.IngredientUnitParentId == Guid.Empty)
            {
                ingredientUnit2.IngredientUnitParentId = null;
            }

            await _unitOfWorks.IngredientUnitRepository.AddAsync(ingredientUnit2);
        }

        await _unitOfWorks.SaveChangeAsync();
    }


}



