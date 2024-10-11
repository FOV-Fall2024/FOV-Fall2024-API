using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Application.Features.DishGenerals.Responses;

public record GetProductGeneralResponse(Guid Id, string DishGeneralName, decimal DishGeneralPrice, string DishGeneralDescription, Status Status, string DishGeneralImage, string CategoryName, DateTime CreatedDate, DateTime UpdateTime, decimal PercentagePriceDifference);

public record GetProductGeneralDetailResponse(Guid Id, string DishGeneralName, string DishGeneralDescription, DateTime CreatedDate, DateTime UpdateDated, List<GetIngredientResponse> GetIngredients,IEnumerable<GetAdditionalImage> Images,string DishGeneralImage);
public record GetIngredientResponse(Guid IngredientGeneralId, string IngredientGeneralName, decimal IngredientGeneralQuantity, DateTime CreatedDate);
public sealed record GetAdditionalImage(Guid DishGeneralImageId,string Url);
