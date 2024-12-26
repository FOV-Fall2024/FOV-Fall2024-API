using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        var customers = await _unitOfWorks.CustomerRepository.GetAllAsync();
        var chosenDate = request.ChosenDate ?? DateTime.Now;
        DateTime startDate, endDate;

        switch (request.TimeFrame)
        {
            case TimeFrame.Week:
                startDate = chosenDate.AddDays(DayOfWeek.Monday - chosenDate.DayOfWeek);
                endDate = startDate.AddDays(7);
                break;

            case TimeFrame.Month:
                startDate = new DateTime(chosenDate.Year, chosenDate.Month, 1);
                endDate = startDate.AddMonths(1);
                break;

            case TimeFrame.Year:
                startDate = new DateTime(chosenDate.Year, 1, 1);
                endDate = startDate.AddYears(1);
                break;

            default:
                throw new Exception("Invalid TimeFrame");
        }

        var filteredCustomers = customers.Where(c => c.Created >= startDate && c.Created < endDate).ToList();

        var restaurantCustomerCounts = filteredCustomers
            .GroupBy(c => c.Orders.FirstOrDefault()?.Table.RestaurantId)
            .Select(g => new RestaurantCustomersDto(
                RestaurantName: g.First().Orders.FirstOrDefault()?.Table.Restaurant.RestaurantName ?? "Unknown",
                TotalCustomers: g.Count()
            ))
            .ToList();

        var sortedResults = request.SortAscending
            ? restaurantCustomerCounts.OrderBy(r => r.TotalCustomers).ToList()
            : restaurantCustomerCounts.OrderByDescending(r => r.TotalCustomers).ToList();

        return sortedResults;
    }
}
