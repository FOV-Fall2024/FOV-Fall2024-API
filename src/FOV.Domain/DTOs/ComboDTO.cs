using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.DTOs;

public sealed record GetComboDetailResponse(Guid Id, string ComboName, decimal Price,string ComboThumbnail,string ComboDescription, List<GetDishComboResponse> DishComboResponses);

public sealed record GetDishComboResponse(Guid DishId, Status Status, string DishName, string DishDescription,int dishQuantity,decimal Price,List<string> DishImages, List<GetIngredientInDishResponse> GetIngredients);
public sealed record GetIngredientInDishResponse(Guid ingredientId, string ingredientName, decimal IngredientQuantity, string IngredientMeasureName, string IngredientType);


