namespace FOV.Application.Features.Ingredients.Responses;

public sealed record GetIngredientsResponse(Guid Id, Guid RestaurantId, string IngredientName, decimal Amount, DateTime CreatedDate, List<GetIngredientUnitResponse> IngredientUnits);

public sealed record GetIngredientUnitResponse(Guid IngredientUnitId, Guid? IngredientUnitParentId, string UnitName, decimal ConversionFactor, DateTime CreatedDate);
