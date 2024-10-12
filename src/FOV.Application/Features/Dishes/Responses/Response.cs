using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Application.Features.Dishes.Responses;

public sealed record GetProductResponse(Guid Id, string DishImage, string ProductName, string ProductDescription, DateTime CreatedDate);

public sealed record GetMenuResponse(Guid Id, string DishName, string DishDescription, DateTime CreatedDate);

public sealed record GetDetailResponse(Guid Id,string DishName,string DishDescription,DateTime CreateDate,List<string> AdditionalImages,List<GetIngredientResponse> GetIngredients);

public sealed record GetIngredientResponse(Guid ingredientId,string ingredientName);
