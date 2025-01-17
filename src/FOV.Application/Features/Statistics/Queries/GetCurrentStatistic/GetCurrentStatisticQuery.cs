using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Statistics.Queries.GetCurrentStatistic;
public record GetCurrentStatisticCommand : IRequest<CurrentStatisticDto>;
public record CurrentStatisticDto(RevenueStatistic RevenueStatistic, OrderStatistic OrderStatistic, CustomerStatistic CustomerStatistic, int? TotalBranches, int? TotalEmployees);
public record RevenueStatistic(decimal TotalRevenue, decimal PercentageAfterLastMonth);
public record OrderStatistic(int TotalOrder, decimal PercentageAfterLastMonth);
public record CustomerStatistic(int TotalCustomer, decimal PercentageAfterLastMonth);
public class GetCurrentStatisticQuery(IUnitOfWorks unitOfWorks, IClaimService claimService, UserManager<User> userManager) : IRequestHandler<GetCurrentStatisticCommand, CurrentStatisticDto>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    private readonly UserManager<User> _userManager = userManager;
    public async Task<CurrentStatisticDto> Handle(GetCurrentStatisticCommand request, CancellationToken cancellationToken)
    {
        var userRole = _claimService.UserRole;
        Guid? restaurantId = null;
        if (userRole == Role.Manager)
        {
            restaurantId = _claimService.RestaurantId;
        }

        var currentMonthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var previousMonthStart = currentMonthStart.AddMonths(-1);
        var previousMonthEnd = currentMonthStart.AddDays(-1);

        var payments = await _unitOfWorks.PaymentRepository.WhereAsync(p => (!restaurantId.HasValue
                                                                             || p.Order.Table.RestaurantId == restaurantId) && p.PaymentStatus == Domain.Entities.PaymentAggregator.Enums.PaymentStatus.Paid && p.IsAdminConfirm,
                                                                       p => p.Order.Table);

        var currentRevenue = payments.Where(p => p.PaymentDate >= currentMonthStart).Sum(p => p.FinalAmount);
        var previousRevenue = payments.Where(p => p.PaymentDate >= previousMonthStart && p.PaymentDate <= previousMonthEnd).Sum(p => p.FinalAmount);
        var revenuePercentage = CalculatePercentageChange(currentRevenue, previousRevenue);

        var orders = await _unitOfWorks.OrderRepository.WhereAsync(o => (!restaurantId.HasValue || o.Table.RestaurantId == restaurantId), o => o.Table);

        var currentOrders = orders.Count(o => o.OrderTime >= currentMonthStart);
        var previousOrders = orders.Count(o => o.OrderTime >= previousMonthStart && o.OrderTime <= previousMonthEnd);
        var ordersPercentage = CalculatePercentageChange(currentOrders, previousOrders);

        var customers = await _unitOfWorks.CustomerRepository.GetAllAsync();
        var currentCustomers = customers.Count(c => c.Created >= currentMonthStart);
        var previousCustomers = customers.Count(c => c.Created >= previousMonthStart && c.Created <= previousMonthEnd);
        var customersPercentage = CalculatePercentageChange(currentCustomers, previousCustomers);

        int? totalBranch = 0;
        if (userRole == Role.Administrator)
        {
            totalBranch = await _unitOfWorks.RestaurantRepository.CountAsync();
        }
        int? totalEmployee = 0;
        if (userRole == Role.Manager)
        {
            totalEmployee = await _userManager.Users.Where(x => x.RestaurantId == restaurantId && x.Status == Status.Active && (x.EmployeeCode.StartsWith("WTR_") || x.EmployeeCode.StartsWith("CKR_"))).CountAsync();
        }

        return new CurrentStatisticDto(new RevenueStatistic(currentRevenue, revenuePercentage),
                                       new OrderStatistic(currentOrders, ordersPercentage),
                                       new CustomerStatistic(currentCustomers, customersPercentage),
                                       totalBranch,
                                       totalEmployee);
    }
    private static decimal CalculatePercentageChange(decimal current, decimal previous)
    {
        if (previous == 0) return current == 0 ? 0 : 100;
        return Math.Round(((current - previous) / previous) * 100, 2);
    }
}
