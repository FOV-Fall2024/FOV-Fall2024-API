namespace FOV.Application.Features.DishGenerals.Responses;

public record GetProductGeneralResponse(Guid Id, string Name, decimal Price, string ProductDescription, bool IsDeleted, string ProductImage, Guid CategoryId, DateTimeOffset CreatedDate, DateTimeOffset UpdateTime);

public record GetProductGeneralDetailResponse(Guid Id, string Name, string Description, DateTimeOffset CreatedDate, DateTimeOffset UpdateDated, List<GetIngredientResponse> GetIngredients);
public record GetIngredientResponse(Guid Id, string Name, decimal Quantity);
