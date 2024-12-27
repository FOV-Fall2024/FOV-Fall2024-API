using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Shared.TimeFrame;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Statistics.Queries.GetTopRestaurantOrders;

public record GetTopRestaurantOrdersCommand(TimeFrame TimeFrame, DateTime? ChosenDate = null, bool SortAscending = false) : IRequest<List<RestaurantOrdersDto>>;
public record RestaurantOrdersDto(string RestaurantName, int TotalOrders);
public class GetTopRestaurantOrdersQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetTopRestaurantOrdersCommand, List<RestaurantOrdersDto>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<List<RestaurantOrdersDto>> Handle(GetTopRestaurantOrdersCommand request, CancellationToken cancellationToken)
    {
        DateTime startDate, endDate;
        var chosenDate = (request.ChosenDate ?? DateTime.Now).ToUniversalTime();

        switch (request.TimeFrame)
        {
            case TimeFrame.Week:
                startDate = chosenDate.AddDays(DayOfWeek.Monday - chosenDate.DayOfWeek).ToUniversalTime();
                endDate = startDate.AddDays(7).ToUniversalTime();
                break;

            case TimeFrame.Month:
                startDate = new DateTime(chosenDate.Year, chosenDate.Month, 1, 0, 0, 0, DateTimeKind.Utc);
                endDate = startDate.AddMonths(1);
                break;

            case TimeFrame.Year:
                startDate = new DateTime(chosenDate.Year, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                endDate = startDate.AddYears(1);
                break;

            default:
                throw new AppException("TimeFrame không hợp lệ");
        }

        var orders = await _unitOfWorks.OrderRepository.WhereAsync(
            o => o.OrderTime >= startDate && o.OrderTime < endDate,
            o => o.Table.Restaurant
        );

        var restaurantOrderCounts = orders
            .GroupBy(o => o.Table.RestaurantId)
            .Select(g => new RestaurantOrdersDto(
                RestaurantName: g.First().Table.Restaurant.RestaurantName,
                TotalOrders: g.Count()
            ))
            .ToList();

        var allRestaurants = await _unitOfWorks.RestaurantRepository.GetAllAsync();

        foreach (var restaurant in allRestaurants)
        {
            if (restaurantOrderCounts.All(r => r.RestaurantName != restaurant.RestaurantName))
            {
                restaurantOrderCounts.Add(new RestaurantOrdersDto(restaurant.RestaurantName, 0));
            }
        }

        var sortedOrders = request.SortAscending
            ? restaurantOrderCounts.OrderBy(r => r.TotalOrders).ToList()
            : restaurantOrderCounts.OrderByDescending(r => r.TotalOrders).ToList();

        return sortedOrders;
    }
}

