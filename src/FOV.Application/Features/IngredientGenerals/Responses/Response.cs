﻿using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Application.Features.IngredientGenerals.Responses;

public record GetAllIngredientResponse(Guid Id, string IngredientGeneralName, string IngredientGeneralType, string ingredientMeasureType, string IngredientGeneralDescription, Status Status);

