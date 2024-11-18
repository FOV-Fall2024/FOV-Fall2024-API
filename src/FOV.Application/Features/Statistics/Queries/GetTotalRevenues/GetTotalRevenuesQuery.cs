using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.PaymentAggregator.Enums;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Statistics.Queries.GetTotalRevenues;
public record GetTotalRevenuesCommand(TimeFrame TimeFrame, DateTime? ChosenDate = null) : IRequest<List<TotalRevenuesDto>>;
public enum TimeFrame
{
    Week,
    Month,
    Year
}
public record TotalRevenuesDto(string TimePeriod, decimal TotalRevenues);
public class GetTotalRevenuesQuery(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetTotalRevenuesCommand, List<TotalRevenuesDto>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<List<TotalRevenuesDto>> Handle(GetTotalRevenuesCommand request, CancellationToken cancellationToken)
    {
        var userRole = _claimService.UserRole;
        List<Domain.Entities.PaymentAggregator.Payments> payments = new();

        if (userRole == Role.Manager)
        {
            var restaurantId = _claimService.RestaurantId;
            payments = await _unitOfWorks.PaymentRepository.WhereAsync(p => p.PaymentStatus == PaymentStatus.Paid && p.Order.Table.RestaurantId == restaurantId, p => p.Order.Table);
        }
        else if (userRole == Role.Administrator)
        {
            payments = await _unitOfWorks.PaymentRepository.WhereAsync(p => p.PaymentStatus == PaymentStatus.Paid, p => p.Order.Table);
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

        payments = payments.Where(p => p.PaymentDate >= startDate && p.PaymentDate < endDate).ToList();
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
            TimeFrame.Week or TimeFrame.Month => periods
                .Select(date => new TotalRevenuesDto(
                    date.ToString("yyyy-MM-dd"),
                    payments.Where(p => p.PaymentDate!.Value.Date == date).Sum(p => p.FinalAmount)))
                .OrderBy(dto => DateTime.ParseExact(dto.TimePeriod, "yyyy-MM-dd", null))
                .ToList(),

            TimeFrame.Year => periods
                .Select(month => new TotalRevenuesDto(
                    $"{month.Year}/{month.Month}",
                    payments.Where(p => p.PaymentDate!.Value.Month == month.Month).Sum(p => p.FinalAmount)))
                .OrderBy(dto => DateTime.ParseExact(dto.TimePeriod, "yyyy/M", null))
                .ToList(),

            _ => throw new AppException("Không tìm thấy TimeFrame")
        };

        return statistics;
    }
}
