using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Shared.TimeFrame;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Statistics.Queries.GetTotalCustomers;
public record GetTotalCustomerCommand(TimeFrame TimeFrame, DateTime? ChosenDate = null, Guid? RestaurantId = null) : IRequest<List<TotalCustomerDtos>>;
public record TotalCustomerDtos(string TimePeriod, int TotalCustomers);
internal class GetTotalCustomerQuery(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetTotalCustomerCommand, List<TotalCustomerDtos>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<List<TotalCustomerDtos>> Handle(GetTotalCustomerCommand request, CancellationToken cancellationToken)
    {
        var userRole = _claimService.UserRole;
        List<Customer> customers = new();

        if (userRole == Role.Manager)
        {
            var restaurantId = _claimService.RestaurantId;
            customers = await _unitOfWorks.CustomerRepository.WhereAsync(
                c => c.Orders.Any(o => o.Table.RestaurantId == restaurantId),
                c => c.Orders);
        }
        else if (userRole == Role.Administrator)
        {
            if (request.RestaurantId.HasValue)
            {
                customers = await _unitOfWorks.CustomerRepository.WhereAsync(
                    c => c.Orders.Any(o => o.Table.RestaurantId == request.RestaurantId),
                    c => c.Orders);
            }
            else
            {
                customers = await _unitOfWorks.CustomerRepository.GetAllAsync();
            }
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

        customers = customers.Where(c => c.Created >= startDate && c.Created < endDate).ToList();
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
            TimeFrame.Week or TimeFrame.Month => periods.Select(date => new TotalCustomerDtos(
                date.ToString("yyyy-MM-dd"),
                customers.Count(c => c.Created.Date == date)
            )).ToList(),

            TimeFrame.Year => periods.Select(date => new TotalCustomerDtos(
                date.ToString("yyyy-MM"),
                customers.Count(c => c.Created.Month == date.Month)
            )).ToList(),

            _ => throw new AppException("Không tìm thấy TimeFrame")
        };

        return statistics;
    }
}
