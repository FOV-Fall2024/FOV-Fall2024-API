using FOV.Application.Features.IngredientUnits.Queries.GetIngredientUnit;
using FOV.Application.Features.IngredientUnits.Responses;
using FOV.Domain.Entities.IngredientAggregator;

namespace FOV.Application.Features.IngredientUnits.Mapper;
public static class IngredientUnitMapper
{
    public static GetIngredientUnitResponse MapperIngredientUnitDTO(this IngredientUnit ingredientUnit)
    {
        return new GetIngredientUnitResponse(ingredientUnit.Id, ingredientUnit.IngredientUnitParentId, ingredientUnit.UnitName, ingredientUnit.ConversionFactor, ingredientUnit.Created);
    }
}
