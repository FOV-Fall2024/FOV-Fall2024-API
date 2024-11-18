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
public record GetTotalRevenuesCommand(TimeFrame TimeFrame, DateTime? StartDate = null, DateTime? EndDate = null) : IRequest<List<TotalRevenuesDto>>;
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

        if (request.StartDate.HasValue)
        {
            payments = payments.Where(p => p.PaymentDate >= request.StartDate).ToList();
        }
        if (request.EndDate.HasValue)
        {
            payments = payments.Where(p => p.PaymentDate <= request.EndDate).ToList();
        }

        var statistics = request.TimeFrame switch
        {
            TimeFrame.Week => payments.Where(p => p.PaymentDate >= DateTime.Now.AddDays(-7))
                                      .GroupBy(p => p.PaymentDate!.Value.Date)
                                      .Select(g => new TotalRevenuesDto(g.Key.ToString("dd/MM/yyyy"), g.Sum(p => p.FinalAmount)))
                                      .ToList(),

            TimeFrame.Month => payments.Where(p => p.PaymentDate >= DateTime.Now.AddMonths(-1))
                                       .GroupBy(p => p.PaymentDate!.Value.Date)
                                       .Select(g => new TotalRevenuesDto(g.Key.ToString("dd/MM/yyyy"), g.Sum(p => p.FinalAmount)))
                                       .ToList(),

            TimeFrame.Year => payments.Where(p => p.PaymentDate >= DateTime.Now.AddYears(-1))
                                      .GroupBy(p => p.PaymentDate!.Value.Month)
                                      .Select(g => new TotalRevenuesDto($"{g.Key}/{DateTime.UtcNow.Year}", g.Sum(p => p.FinalAmount)))
                                      .ToList(),

            _ => throw new AppException("Không tìm thấy TimeFrame")
        };

        return statistics;
    }
}
