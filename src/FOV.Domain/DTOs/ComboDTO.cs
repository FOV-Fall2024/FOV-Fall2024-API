using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.DTOs;

public sealed record GetComboDetailResponse(Guid Id, string ComboName, decimal Price, List<GetDishComboResponse> DishComboResponses);

public sealed record GetDishComboResponse(Guid DishId, Status Status, string DishName, string DishDescription, List<GetIngredientInDishResponse> GetIngredients);
public sealed record GetIngredientInDishResponse(Guid IngredientId, string IngredientName);


