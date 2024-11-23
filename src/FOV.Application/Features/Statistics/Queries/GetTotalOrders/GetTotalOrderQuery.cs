using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Shared.TimeFrame;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Statistics.Queries.GetTotalOrders;
public record GetTotalOrderCommand(TimeFrame TimeFrame, DateTime? ChosenDate = null) : IRequest<List<TotalOrderDtos>>;
public record TotalOrderDtos(string TimePeriod, int TotalOrders);
public class GetTotalOrderQuery(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetTotalOrderCommand, List<TotalOrderDtos>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<List<TotalOrderDtos>> Handle(GetTotalOrderCommand request, CancellationToken cancellationToken)
    {
        var userRole = _claimService.UserRole;
        List<Domain.Entities.OrderAggregator.Order> orders = new();
        if (userRole == Role.Manager)
        {
            var restaurantId = _claimService.RestaurantId;
            orders = await _unitOfWorks.OrderRepository.WhereAsync(o => o.Table.RestaurantId == restaurantId, o => o.Table);
        }
        else if (userRole == Role.Administrator)
        {
            orders = await _unitOfWorks.OrderRepository.GetAllAsync();
        }

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

        orders = orders.Where(o => o.OrderTime >= startDate && o.OrderTime < endDate).ToList();
        var periods = request.TimeFrame switch
        {
            TimeFrame.Week or TimeFrame.Month => Enumerable.Range(0, (endDate - startDate).Days)
                .Select(offset => startDate.AddDays(offset).Date),
            TimeFrame.Year => Enumerable.Range(0, 12)
                .Select(month => new DateTime(startDate.Year, month + 1, 1)),
            _ => throw new AppException("Không tìm thấy TimeFrame")
        };

        var statistics = request.TimeFrame switch
        {
            TimeFrame.Week or TimeFrame.Month => periods.Select(p => new TotalOrderDtos(p.ToString("yyyy-MM-dd"), orders.Count(o => o.OrderTime.Date == p))).ToList(),
            TimeFrame.Year => periods.Select(p => new TotalOrderDtos(p.ToString("yyyy-M"), orders.Count(o => o.OrderTime.Month == p.Month && o.OrderTime.Year == p.Year))).ToList(),
            _ => throw new AppException("Không tìm thấy TimeFrame")
        };

        return statistics;
    }
}
