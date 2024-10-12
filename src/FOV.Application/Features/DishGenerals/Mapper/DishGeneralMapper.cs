using FOV.Application.Features.DishGenerals.Queries.GetProductGeneralDetail;
using FOV.Application.Features.DishGenerals.Responses;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator;

namespace FOV.Application.Features.DishGenerals.Mapper;
public static class DishGeneralMapper
{

    public static GetIngredientResponse MapperIngredientDTO(this IngredientGeneral ingredient, Guid productId)
    {
        return new GetIngredientResponse(ingredient.Id, ingredient.IngredientName, ingredient.DishIngredientGenerals.Where(x => x.DishGeneralId == productId).FirstOrDefault().Quantity, ingredient.IngredientMeasure.ToString() ,ingredient.Created);
    }

    public static GetProductGeneralDetailResponse MapperDetailDTO(this DishGeneral dishGeneral, List<GetIngredientResponse>? getIngredient)
    {
        return new GetProductGeneralDetailResponse(dishGeneral.Id, dishGeneral.DishName, dishGeneral.DishDescription, dishGeneral.Created, dishGeneral.LastModified ?? DateTime.Now, getIngredient ?? [], dishGeneral.DishGeneralImages.Select(x =>new GetAdditionalImage(x.Id,x.Url)), dishGeneral.Price, dishGeneral.PercentagePriceDifference);
    }
}
