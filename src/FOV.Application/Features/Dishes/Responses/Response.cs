using FOV.Application.Features.DishGenerals.Responses;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Application.Features.Dishes.Responses;

public sealed record GetProductResponse(Guid Id, string DishImage, string ProductName, string ProductDescription, DateTime CreatedDate);

public sealed record GetMenuResponse(Guid Id, string DishName, int Quantity, string Price, decimal PercentagePriceDifference, string DishDescription, DateTime CreatedDate, List<GetAdditionalImage> Images, string CategoryName, string Type, Status Status);

public sealed record GetDetailResponse(Guid Id, string DishName, string Price, decimal PercentagePriceDifference, string DishDescription, DateTime CreateDate, List<string> Images, List<GetIngredientResponse> Ingredients, string CategoryName, Status Status);

public sealed record GetIngredientResponse(Guid ingredientId, string ingredientName, string IngredientQuantity, string IngredientMeasureName, string IngredientType);
