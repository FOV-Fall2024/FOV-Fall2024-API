using FOV.Domain.Entities.IngredientGeneralAggregator.Enums;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Application.Features.IngredientGenerals.Responses;

public record GetAllIngredientResponse(Guid Id, string IngredientGeneralName, string IngredientGeneralType, string ingredientMeasureType, string IngredientGeneralDescription, Status Status,DateTime CreatedDate);
public record GetDetailIngredientGeneralResponse(Guid Id, string IngredientGeneralName, Guid IngredientGeneralType, string IngredientGeneralTypeName, IngredientMeasure IngredientMeasureType, string IngredientGeneralDescription, Status Status, DateTime CreatedDate);

