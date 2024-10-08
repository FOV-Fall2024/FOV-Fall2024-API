namespace FOV.Application.Features.DishGenerals.Responses;

public record GetProductGeneralResponse(Guid Id, string DishGeneralName, decimal DishGeneralPrice, string DishGeneralDescription, bool IsDeleted, string DishGeneralImage, Guid CategoryId, DateTime CreatedDate, DateTime UpdateTime);

public record GetProductGeneralDetailResponse(Guid Id, string DishGeneralName, string DishGeneralDescription, DateTime CreatedDate, DateTime UpdateDated, List<GetIngredientResponse> GetIngredients);
public record GetIngredientResponse(Guid IngredientGeneralId, string IngredientGeneralName, decimal IngredientGeneralQuantity, DateTime CreatedDate);
