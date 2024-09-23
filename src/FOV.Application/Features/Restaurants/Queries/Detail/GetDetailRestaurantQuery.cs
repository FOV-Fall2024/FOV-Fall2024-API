using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Domain.DTOs;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Domain.Entities.ProductAggregator.Enums;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Restaurants.Queries.Detail;
public sealed record GetRestaurantDetailCommand(Guid Id) : IRequest<GetRestaurantDetailResponse>;
public sealed record GetRestaurantDetailResponse(Guid Id, string RestaurantName, string Address, string RestaurantPhone, Status Status, ProductDto? Product);
public sealed record ProductDto(Guid ProductId, string ProductName, string ProductDescription, ProductType ProductType, decimal Price);
public class GetDetailRestaurantQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetRestaurantDetailCommand, GetRestaurantDetailResponse>
{
    private IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<GetRestaurantDetailResponse> Handle(GetRestaurantDetailCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(request.Id, r => r.Products);

        var product = restaurant.Products.FirstOrDefault();

        var response = new GetRestaurantDetailResponse(
            restaurant.Id,
            restaurant.RestaurantName,
            restaurant.Address,
            restaurant.RestaurantPhone,
            restaurant.Status,
            product != null
                ? new ProductDto(
                    product.Id,
                    product.ProductName,
                    product.ProductDescription,
                    product.ProductType,
                    product.Price ?? 0
                )
                : null
        );

        return response;
    }
}
