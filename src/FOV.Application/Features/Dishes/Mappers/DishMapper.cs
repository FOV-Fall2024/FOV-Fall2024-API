using FOV.Application.Features.Dishes.Responses;
using FOV.Domain.Entities.DishAggregator;

namespace FOV.Application.Features.Dishes.Mappers;


public static class DishMapper
{
    public static GetDetailResponse MapperDetailDTO(this Dish dish, List<string> Images, List<DishIngredient> dishIngredients)
    {
        return new GetDetailResponse(dish.Id, dish.DishName, dish.DishDescription, dish.Created, dish.DishMainImage, Images, dishIngredients.Select(ingredient => new GetIngredientResponse(ingredient.Id, ingredient.Ingredient.IngredientName)).ToList());
    }
}
