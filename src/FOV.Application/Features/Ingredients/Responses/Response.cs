namespace FOV.Application.Features.Ingredients.Responses;

public sealed record GetIngredientsResponse(Guid Id, Guid RestaurantId, string IngredientName, decimal Amount, DateTime CreatedDate);
