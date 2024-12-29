using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Shared.TimeFrame;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Statistics.Queries.GetTopRestaurantCustomers;
public record GetTopRestaurantCustomersCommand(TimeFrame TimeFrame, DateTime? ChosenDate = null, bool SortAscending = false) : IRequest<List<RestaurantCustomersDto>>;
public record RestaurantCustomersDto(string RestaurantName, int TotalCustomers);
public class GetTopRestaurantCustomersQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetTopRestaurantCustomersCommand, List<RestaurantCustomersDto>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<List<RestaurantCustomersDto>> Handle(GetTopRestaurantCustomersCommand request, CancellationToken cancellationToken)
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
                throw new AppException("Invalid TimeFrame");
        }

        var restaurants = await _unitOfWorks.RestaurantRepository.GetAllAsync();

        var orders = await _unitOfWorks.OrderRepository.WhereAsync(
            o => o.Created >= startDate && o.Created <= endDate,
            o => o.Table.Restaurant
        );

        var restaurantCustomersQuery = restaurants
            .GroupJoin(orders,
                restaurant => restaurant.Id,
                order => order.Table.Restaurant.Id,
                (restaurant, orderGroup) => new RestaurantCustomersDto(
                    RestaurantName: restaurant.RestaurantName,
                    TotalCustomers: orderGroup.Select(o => o.CustomerId).Distinct().Count()
                ))
            .ToList();

        var sortedRestaurantCustomers = request.SortAscending
            ? restaurantCustomersQuery.OrderBy(r => r.TotalCustomers).ToList()
            : restaurantCustomersQuery.OrderByDescending(r => r.TotalCustomers).ToList();

        return sortedRestaurantCustomers;
    }
}
