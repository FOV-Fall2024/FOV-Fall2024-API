using FOV.Application.Features.ProductGenerals.Queries.GetProductGeneralDetail;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.ProductGeneralAggregator;

namespace FOV.Application.Features.ProductGenerals.Mapper;
public static class ProductGeneralMapper
{

    public static GetIngredientResponse MapperIngredientDTO(this IngredientGeneral ingredient, Guid productId)
    {
        return new GetIngredientResponse(ingredient.Id, ingredient.IngredientName, ingredient.ProductIngredientGenerals.First(x => x.ProductGeneralId == productId).Quantity);
    }

    public static GetProductGeneralDetailResponse MapperDetailDTO(this ProductGeneral productGeneral, List<GetIngredientResponse> getIngredient)
    {
        return new GetProductGeneralDetailResponse(productGeneral.Id, productGeneral.ProductName, productGeneral.ProductDescription, productGeneral.Created, productGeneral.LastModified, getIngredient);
    }
}
