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

    public class GetDetailRestaurantQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetRestaurantDetailCommand, GetRestaurantDetailResponse>
    {
        private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

        public async Task<GetRestaurantDetailResponse> Handle(GetRestaurantDetailCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(request.Id, r => r.Dishes, r => r.Combos);

            var products = restaurant.Dishes.Select(product => new ProductDto(
                product.Id,
                product.DishName,
                product.DishDescription,
                product.DishType,
                product.Price ?? 0
            )).ToList();

            var combos = restaurant.Combos.Select(combo => new ComboDto(
                combo.Id,
                combo.ComboName,
                combo.Quantity,
                combo.Price,
                combo.PercentReduce,
                combo.ExpiredDate
            )).ToList();

            var response = new GetRestaurantDetailResponse(
                restaurant.Id,
                restaurant.RestaurantName,
                restaurant.Address,
                restaurant.RestaurantPhone,
                restaurant.Status,
                products,
                combos
            );

            return response;
        }
    }
}
