using FOV.Domain.Entities.DishAggregator.Enums;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Restaurants.Queries.Detail;
public sealed record GetRestaurantDetailCommand(Guid Id) : IRequest<GetRestaurantDetailResponse>;
public sealed record GetRestaurantDetailResponse(Guid Id, string RestaurantName, string Address, string RestaurantPhone, Status Status, ProductDto? Product);
public sealed record ProductDto(Guid ProductId, string ProductName, string ProductDescription, DishType ProductType, decimal Price);
public class GetDetailRestaurantQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetRestaurantDetailCommand, GetRestaurantDetailResponse>
{
    private IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<GetRestaurantDetailResponse> Handle(GetRestaurantDetailCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(request.Id, r => r.Dishes);

        var product = restaurant.Dishes.FirstOrDefault();

        var response = new GetRestaurantDetailResponse(
            restaurant.Id,
            restaurant.RestaurantName,
            restaurant.Address,
            restaurant.RestaurantPhone,
            restaurant.Status,
            product != null
                ? new ProductDto(
                    product.Id,
                    product.DishName,
                    product.DishDescription,
                    product.DishType,
                    product.Price ?? 0
                )
                : null
        );

        return response;
    }
}
