using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Shared.TimeFrame;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Statistics.Queries.GetDetailsRestaurants;
public record GetDetailsRestaurantsDetailsCommand(TimeFrame TimeFrame, Guid RestaurantId, DateTime? ChosenDate = null, int TopNDish = 5, int TopNRefundableDish = 5, int TopNCombo = 5, bool SortAscending = false) : IRequest<GetDetailsRestaurantsDetailsResponse>;
public record GetDetailsRestaurantsDetailsResponse(Guid RestaurantId, string RestaurantName, string Address, string RestaurantPhone, string RestaurantStatus, ICollection<TopDishDtos> TopDishes, ICollection<TopRefundableDishDtos> TopRefundableDish, ICollection<GetTopComboDtos> TopCombos);
public sealed record TopDishDtos(Guid DishId, string DishName, string DishDescription, decimal? Price, string DishStatus, int Quantity);
public sealed record TopRefundableDishDtos(Guid DishId, string DishName, string DishDescription, decimal? Price, string DishStatus, int Quantity);
public sealed record GetTopComboDtos(Guid ComboId, string ComboName, decimal Price, decimal PercentReduce, string ComboStatus, int Quantity);
public class GetDetailsRestaurantsQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetDetailsRestaurantsDetailsCommand, GetDetailsRestaurantsDetailsResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<GetDetailsRestaurantsDetailsResponse> Handle(GetDetailsRestaurantsDetailsCommand request, CancellationToken cancellationToken)
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

        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(request.RestaurantId, x => x.Tables) ?? throw new AppException("Không tìm thấy nhà hàng");

        var orders = await _unitOfWorks.OrderRepository.WhereAsync(
            o => o.Created >= startDate && o.Created <= endDate && o.Table.RestaurantId == request.RestaurantId,
            o => o.OrderDetails
            );

        var topDishes = orders
            .SelectMany(o => o.OrderDetails)
            .Where(od => od.ProductId.HasValue)
            .GroupBy(od => od.ProductId)
            .Select(g => new
            {
                DishId = g.Key,
                TotalQuantity = g.Sum(od => od.Quantity),
                IsRefundDish = g.Any(od => od.IsRefund)
            })
            .ToList();

        var normalDishes = topDishes
            .Where(d => !d.IsRefundDish)
            .OrderBy(x => request.SortAscending ? x.TotalQuantity : -x.TotalQuantity)
            .Take(request.TopNDish);

        var refundDishes = topDishes
            .Where(d => d.IsRefundDish)
            .OrderBy(x => request.SortAscending ? x.TotalQuantity : -x.TotalQuantity)
            .Take(request.TopNRefundableDish);

        var normalDishDtos = (await _unitOfWorks.DishRepository.WhereAsync(
            d => normalDishes.Select(t => t.DishId).Contains(d.Id) && d.RestaurantId == request.RestaurantId, d => d.DishGeneral
                )).Select(d => new TopDishDtos(
                    d.Id,
                    d.DishGeneral.DishName,
                    d.DishGeneral.DishDescription,
                    d.Price,
                    d.Status.ToString(),
                    normalDishes.FirstOrDefault(t => t.DishId == d.Id)?.TotalQuantity ?? 0
                ))
                .OrderBy(x => request.SortAscending ? x.Quantity : -x.Quantity)
                .ToList();

        var refundDishDtos = (await _unitOfWorks.DishRepository.WhereAsync(
            d => refundDishes.Select(t => t.DishId).Contains(d.Id) && d.RestaurantId == request.RestaurantId, d => d.DishGeneral
                )).Select(d => new TopRefundableDishDtos(
                    d.Id,
                    d.DishGeneral.DishName,
                    d.DishGeneral.DishDescription,
                    d.Price,
                    d.Status.ToString(),
                    refundDishes.FirstOrDefault(t => t.DishId == d.Id)?.TotalQuantity ?? 0
                ))
                .OrderBy(x => request.SortAscending ? x.Quantity : -x.Quantity)
                .ToList();

        var topCombos = orders
            .SelectMany(o => o.OrderDetails)
            .Where(od => od.ComboId.HasValue)
            .GroupBy(od => od.ComboId)
            .Select(g => new
            {
                ComboId = g.Key,
                TotalQuantity = g.Sum(od => od.Quantity)
            })
            .OrderBy(x => request.SortAscending ? x.TotalQuantity : -x.TotalQuantity)
            .Take(request.TopNCombo)
            .ToList();

        var combos = await _unitOfWorks.ComboRepository.WhereAsync(
            c => topCombos.Select(t => t.ComboId).Contains(c.Id)
        );

        var comboDtos = combos
            .Select(c => new GetTopComboDtos(
                c.Id,
                c.ComboName,
                c.Price,
                c.PercentReduce,
                c.Status.ToString(),
                topCombos.FirstOrDefault(t => t.ComboId == c.Id)?.TotalQuantity ?? 0
            ))
            .OrderBy(c => request.SortAscending ? c.Quantity : -c.Quantity)
            .ToList();

        return new GetDetailsRestaurantsDetailsResponse(
            restaurant.Id,
            restaurant.RestaurantName,
            restaurant.Address,
            restaurant.RestaurantPhone,
            restaurant.Status.ToString(),
            normalDishDtos,
            refundDishDtos,
            comboDtos
        );
    }
}
