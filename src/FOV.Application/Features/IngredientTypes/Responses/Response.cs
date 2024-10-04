﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Application.Features.IngredientTypes.Responses;

public record GetChildrenIngredientType(Guid Id, int Left, int Right, string IngredientTypeName, string ingredientTypeDescription);

public record GetParentCategoriesResponse(Guid Id, string Name);
