﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.RestaurantAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Restaurants.Queries.Get;
public record GetRestaurantCommand(PagingRequest? PagingRequest, Guid? RestaurantId, string? RestaurantName, string? Address, string? RestaurantPhone, string? RestaurantCode) : IRequest<PagedResult<GetRestaurantResponse>>;
public record GetRestaurantResponse(Guid Id, string RestaurantName, string Address, string RestaurantPhone, string RestaurantCode, Status RestaurantStatus);
public class GetRestaurantQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetRestaurantCommand, PagedResult<GetRestaurantResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<PagedResult<GetRestaurantResponse>> Handle(GetRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurants = (await _unitOfWorks.RestaurantRepository.GetAllAsync()).OrderByDescending(r => r.Created);
        var filterEntity = new Restaurant
        {
            Id = request.RestaurantId.HasValue ? request.RestaurantId.Value : Guid.Empty,
            RestaurantName = string.IsNullOrEmpty(request.RestaurantName) ? string.Empty : request.RestaurantName,
            Address = string.IsNullOrEmpty(request.Address) ? string.Empty : request.Address,
            RestaurantPhone = string.IsNullOrEmpty(request.RestaurantPhone) ? string.Empty : request.RestaurantPhone,
            RestataurantCode = string.IsNullOrEmpty(request.RestaurantCode) ? string.Empty : request.RestaurantCode,
            Status = request.RestaurantId.HasValue ? Status.Active : Status.Inactive
        };
        var filteredRestaurants = restaurants.AsQueryable().CustomFilterV1(filterEntity);

        var mappedRestaurants = filteredRestaurants.Select(restaurant => new GetRestaurantResponse(
                restaurant.Id,
                restaurant.RestaurantName ?? string.Empty,
                restaurant.Address ?? string.Empty,
                restaurant.RestaurantPhone ?? string.Empty,
                restaurant.RestataurantCode ?? string.Empty,
                restaurant.Status
            )).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        var sortedResults = PaginationHelper<GetRestaurantResponse>.Sorting(sortType, mappedRestaurants, sortField);
        var result = PaginationHelper<GetRestaurantResponse>.Paging(sortedResults, page, pageSize);

        return result;
        //return filterRestaurant.Select(restaurant => new GetRestaurantResponse(restaurant.Id, restaurant.RestaurantName ?? string.Empty, restaurant.Address ?? string.Empty, restaurant.RestaurantPhone ?? string.Empty, restaurant.RestataurantCode ?? string.Empty, restaurant.Status)).ToList();
    }
}
