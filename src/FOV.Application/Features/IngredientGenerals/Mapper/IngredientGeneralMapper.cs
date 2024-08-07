﻿
using FOV.Application.Features.IngredientGenerals.Queries.GetAllIngredientGeneral;
using FOV.Domain.Entities.IngredientGeneralAggregator;

namespace FOV.Application.Features.IngredientGenerals.Mapper;
public static class IngredientGeneralMapper
{
    public static GetAllIngredientResponse MapperGetAllDTO(this IngredientGeneral ingredientGeneral)
    {
        return new GetAllIngredientResponse(ingredientGeneral.Id, ingredientGeneral.IngredientName, ingredientGeneral.IngredientTypeId, ingredientGeneral.IngredientDescription);
    }
}
