namespace FOV.Application.Features.IngredientUnits.Responses;

public sealed record GetIngredientUnitResponse(Guid IngredientUnitId, Guid? IngredientUnitParentId, string UnitName, decimal ConversionFactor, DateTime CreatedDate);

