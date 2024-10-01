using FOV.Domain.Entities.DishAggregator.Enums;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Restaurants.Queries.Detail
{
    public sealed record GetRestaurantDetailCommand(Guid Id) : IRequest<GetRestaurantDetailResponse>;

    public sealed record GetRestaurantDetailResponse(
        Guid Id,
        string RestaurantName,
        string Address,
        string RestaurantPhone,
        Status Status,
        ICollection<ProductDto> Products
    );

    public sealed record ProductDto(
        Guid ProductId,
        string ProductName,
        string ProductDescription,
        DishType ProductType,
        decimal Price
    );

    public class GetDetailRestaurantQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetRestaurantDetailCommand, GetRestaurantDetailResponse>
    {
        private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

        public async Task<GetRestaurantDetailResponse> Handle(GetRestaurantDetailCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(request.Id, r => r.Dishes);

            var products = restaurant.Dishes.Select(product => new ProductDto(
                product.Id,
                product.DishName,
                product.DishDescription,
                product.DishType,
                product.Price ?? 0
            )).ToList();

            var response = new GetRestaurantDetailResponse(
                restaurant.Id,
                restaurant.RestaurantName,
                restaurant.Address,
                restaurant.RestaurantPhone,
                restaurant.Status,
                products
            );

            return response;
        }
    }
}
