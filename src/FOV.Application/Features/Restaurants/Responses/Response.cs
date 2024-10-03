using FOV.Domain.Entities.DishAggregator.Enums;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Application.Features.Restaurants.Responses;
public sealed record GetRestaurantDetailResponse(
     Guid Id,
     string RestaurantName,
     string Address,
     string RestaurantPhone,
     Status Status,
     ICollection<ProductDto> Products,
     ICollection<ComboDto> Combos
 );

public sealed record ProductDto(
    Guid ProductId,
    string ProductName,
    string ProductDescription,
    DishType ProductType,
    decimal Price
);
public sealed record ComboDto(
    Guid ComboId,
    string ComboName,
    int Quantity,
    decimal Price,
    decimal PercentReduce,
    DateTime ExpiredDate
);
internal class Response
{
}
