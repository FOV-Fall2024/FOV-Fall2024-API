using FOV.Application.Features.Dishes.Responses;
using FOV.Domain.Entities.DishAggregator;

namespace FOV.Application.Features.Dishes.Mappers;


public static class DishMapper
{
    public static GetDetailResponse MapperDetailDTO(this Dish dish, List<string> Images, List<DishIngredient> dishIngredients)
    {
        return new GetDetailResponse(dish.Id, dish.DishGeneral.DishName, dish.Price.ToString(), dish.DishGeneral.PercentagePriceDifference, dish.DishGeneral.DishDescription, dish.Created, Images, dishIngredients.Select(ingredient => new GetIngredientResponse(ingredient.Id, ingredient.Ingredient.IngredientGeneral.IngredientName, ingredient.Quantity.ToString(), ingredient.Ingredient.IngredientMeasure.ToString(), ingredient.Ingredient.IngredientType.IngredientName)).ToList(), dish.Category.CategoryName, dish.Status);
    }
}
