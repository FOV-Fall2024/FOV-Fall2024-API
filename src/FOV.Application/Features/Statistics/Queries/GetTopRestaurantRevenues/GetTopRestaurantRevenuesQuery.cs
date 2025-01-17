﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Shared.TimeFrame;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Statistics.Queries.GetTopRestaurantRevenues;
public record GetTopRestaurantRevenuesCommand(TimeFrame TimeFrame, DateTime? ChosenDate = null, bool SortAscending = false) : IRequest<List<RestaurantRevenuesDto>>;
public record RestaurantRevenuesDto(string RestaurantName, decimal TotalRevenues);
public class GetTopRestaurantRevenuesQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetTopRestaurantRevenuesCommand, List<RestaurantRevenuesDto>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<List<RestaurantRevenuesDto>> Handle(GetTopRestaurantRevenuesCommand request, CancellationToken cancellationToken)
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

        var payments = await _unitOfWorks.PaymentRepository.WhereAsync(
            p => p.PaymentStatus == Domain.Entities.PaymentAggregator.Enums.PaymentStatus.Paid &&
                 p.PaymentDate >= startDate && p.PaymentDate < endDate,
            p => p.Order.Table.Restaurant);

        var restaurantRevenue = payments
            .GroupBy(p => p.Order.Table.RestaurantId)
            .Select(g => new RestaurantRevenuesDto(
                g.First().Order.Table.Restaurant.RestaurantName,
                g.Sum(p => p.FinalAmount)
            ))
            .ToList();

        var allRestaurants = await _unitOfWorks.RestaurantRepository.GetAllAsync();
        foreach (var restaurant in allRestaurants)
        {
            if (restaurantRevenue.All(r => r.RestaurantName != restaurant.RestaurantName))
            {
                restaurantRevenue.Add(new RestaurantRevenuesDto(restaurant.RestaurantName, 0));
            }
        }

        var sortedRevenue = request.SortAscending
            ? restaurantRevenue.OrderBy(r => r.TotalRevenues).ToList()
            : restaurantRevenue.OrderByDescending(r => r.TotalRevenues).ToList();

        return sortedRevenue;
    }
}
