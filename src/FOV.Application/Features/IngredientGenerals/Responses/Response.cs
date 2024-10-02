namespace FOV.Application.Features.IngredientGenerals.Responses;

public record GetAllIngredientResponse(Guid Id, string IngredientName, Guid IngredientTypeId, string IngredientDescription);

