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
                throw new AppException("TimeFrame không hợp lệ");
        }

        var orders = await _unitOfWorks.OrderRepository.GetAllAsync(o => o.Table);

        var filteredOrders = orders.Where(o => o.OrderTime >= startDate && o.OrderTime < endDate)
                                    .GroupBy(o => o.Table.RestaurantId)
                                    .Select(g => new RestaurantOrdersDto(
                                        RestaurantName: g.First().Table.Restaurant.RestaurantName,
                                        TotalOrders: g.Count()
                                    ));

        var sortedOrders = request.SortAscending
            ? filteredOrders.OrderBy(o => o.TotalOrders).ToList()
            : filteredOrders.OrderByDescending(o => o.TotalOrders).ToList();

        return sortedOrders;
    }
}
