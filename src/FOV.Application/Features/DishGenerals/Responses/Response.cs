namespace FOV.Application.Features.DishGenerals.Responses;

public record GetProductGeneralResponse(Guid Id, string DishGeneralName, decimal DishGeneralPrice, string DishGeneralDescription, int Status, string DishGeneralImage, Guid CategoryId, DateTime CreatedDate, DateTime UpdateTime, decimal PercentagePriceDifference);

public record GetProductGeneralDetailResponse(Guid Id, string DishGeneralName, string DishGeneralDescription, DateTime CreatedDate, DateTime UpdateDated, List<GetIngredientResponse> GetIngredients);
public record GetIngredientResponse(Guid IngredientGeneralId, string IngredientGeneralName, decimal IngredientGeneralQuantity, DateTime CreatedDate);
