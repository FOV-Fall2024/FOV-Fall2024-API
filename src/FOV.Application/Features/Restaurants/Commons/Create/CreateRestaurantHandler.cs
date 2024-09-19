﻿using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientAggregator.Enums;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator.Enums;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Restaurants.Commons.Create;

public sealed record CreateRestaurantCommand : IRequest<Guid>
{
    public required string RestaurantName { get; set; }

    public required string Address { get; set; }

    public required string Phone { get; set; }

    public ICollection<Guid> Products { get; set; } = [];
}



internal class CreateRestaurantHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateRestaurantCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        bool existRestaurantname = await _unitOfWorks.RestaurantRepository.AnyAsync(r =>
            r.RestaurantName == request.RestaurantName);

        if (existRestaurantname)
        {
            throw new Exception("Đã có nhà hàng trùng tên");
        }

        bool existAddress = await _unitOfWorks.RestaurantRepository.AnyAsync(r =>
                   r.Address == request.Address);

        if (existAddress)
        {
            throw new Exception("Đã có nhà hàng trùng địa chỉ");
        }

        bool existPhone = await _unitOfWorks.RestaurantRepository.AnyAsync(r =>
                          r.RestaurantPhone == request.Phone);
        if (existPhone)
        {
            throw new Exception("Đã có nhà hàng trùng số điện thoại");
        }

        Restaurant restaurant = new(request.RestaurantName, request.Address, request.Phone, await GeneratedCode());
        await _unitOfWorks.RestaurantRepository.AddAsync(restaurant);
        await AddNewProdut(request.Products, restaurant.Id);
        await _unitOfWorks.SaveChangeAsync();
        return restaurant.Id;
    }


    //private async Task<string> GeneratedCode()
    //{
    //    Restaurant? restaurant = (await _unitOfWorks.RestaurantRepository
    //        .GetAllAsync())
    //        .OrderByDescending(r => r.Created)
    //        .FirstOrDefault();

    //    if (restaurant is null)
    //    {
    //        return "RE_001";
    //    }
    //    string currentIdentifier = restaurant.RestataurantCode; // Assuming restaurant has a property 'Identifier' like 'RE_001'
    //    int currentNumber = int.Parse(currentIdentifier.Substring(3));
    //    int newNumber = currentNumber + 1;
    //    return $"RE_{newNumber:D3}";

    //}
    private async Task<string> GeneratedCode()
    {
        string GenerateNewCode(int number)
        {
            return $"RE_{number:D3}";
        }

        string newCode;
        int codeNumber = 1;

        do
        {
            newCode = GenerateNewCode(codeNumber);
            codeNumber++;
        } while (await _unitOfWorks.RestaurantRepository.AnyAsync(r => r.RestataurantCode == newCode));

        return newCode;
    }


    private async Task AddNewProdut(ICollection<Guid> products, Guid restaurantId)
    {
        foreach (var product in products)
        {
            ProductGeneral productGeneral = await _unitOfWorks.ProductGeneralRepository.GetByIdAsync(product, x => x.Ingredients) ?? throw new Exception();
            var ingredientGenerals = await _unitOfWorks.IngredientGeneralRepository.WhereAsync(x => x.ProductIngredientGenerals.Any(pg => pg.ProductGeneralId == productGeneral.Id));
            Product productAdding = new(productGeneral.ProductName, restaurantId, productGeneral.CategoryId, productGeneral.Id);
            await _unitOfWorks.ProductRepository.AddAsync(productAdding);
            await ProductIngredientAdd(ingredientGenerals.Select(x => x.IngredientName).ToList(), restaurantId, productAdding.Id);
        }
    }

    private async Task ProductIngredientAdd(ICollection<string> ingredientNames, Guid restaurantId, Guid productId)
    {
        foreach (var item in ingredientNames)
        {
            Ingredient? ingredient = _unitOfWorks.IngredientRepository.FirstOrDefaultAsync(x => x.IngredientName == item && x.RestaurantId == restaurantId).Result;
            if (ingredient == null)
            {
                IngredientGeneral ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository.FirstOrDefaultAsync(x => x.IngredientName == item) ?? throw new Exception();
                Ingredient ingredient1 = new(ingredientGeneral.IngredientName, ingredientGeneral.IngredientTypeId, restaurantId);

                await _unitOfWorks.IngredientRepository.AddAsync(ingredient1);
                await _unitOfWorks.ProductIngredientRepository.AddAsync(new ProductIngredient(productId, ingredient1.Id));
                await AddDefaultIngredientUnit(ingredient1.Id, ingredientGeneral.IngredientMeasure);
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



