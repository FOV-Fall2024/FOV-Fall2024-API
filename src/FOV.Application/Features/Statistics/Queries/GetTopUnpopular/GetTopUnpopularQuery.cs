using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Shared.TimeFrame;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Statistics.Queries.GetTopUnpopular;
public record GetTopUnpopularCommand(TimeFrame TimeFrame, Guid RestaurantId, DateTime? ChosenDate = null, int TopNDish = 5, int TopNRefundableDish = 5, int TopNCombo = 5, bool SortAscending = false) : IRequest<GetTopUnpopularResponse>;
public record GetTopUnpopularResponse(Guid RestaurantId, string RestaurantName, string Address, string RestaurantPhone, string RestaurantStatus, ICollection<TopDishDtos> TopDishes, ICollection<TopRefundableDishDtos> TopRefundableDish, ICollection<GetTopComboDtos> TopCombos);
public sealed record TopDishDtos(Guid DishId, string DishName, string DishDescription, decimal? Price, string DishStatus, int Quantity);
public sealed record TopRefundableDishDtos(Guid DishId, string DishName, string DishDescription, decimal? Price, string DishStatus, int Quantity);
public sealed record GetTopComboDtos(Guid ComboId, string ComboName, decimal Price, decimal PercentReduce, string ComboStatus, int Quantity);

public class GetTopUnpopularQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetTopUnpopularCommand, GetTopUnpopularResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<GetTopUnpopularResponse> Handle(GetTopUnpopularCommand request, CancellationToken cancellationToken)
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

        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(request.RestaurantId, x => x.Tables)
            ?? throw new AppException("Không tìm thấy nhà hàng");

        var orders = await _unitOfWorks.OrderRepository.WhereAsync(
            o => o.Created >= startDate && o.Created <= endDate && o.Table.RestaurantId == request.RestaurantId,
            o => o.OrderDetails
        );

        var allDishes = await _unitOfWorks.DishRepository.WhereAsync(d => d.RestaurantId == request.RestaurantId, d => d.DishGeneral, d => d.RefundDishInventory);
        var refundDishInventory = await _unitOfWorks.RefundDishInventoryRepository.WhereAsync(rdi => rdi.Dish.RestaurantId == request.RestaurantId, rdi => rdi.Dish, rdi => rdi.Dish.DishGeneral);
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

        var allCombos = await _unitOfWorks.ComboRepository.WhereAsync(c => c.RestaurantId == request.RestaurantId);

        var topCombos = orders
            .SelectMany(o => o.OrderDetails)
            .Where(od => od.ComboId.HasValue)
            .GroupBy(od => od.ComboId)
            .Select(g => new
            {
                ComboId = g.Key,
                TotalQuantity = g.Sum(od => od.Quantity)
            })
            .ToList();

        var allNormalDishDtos = topDishes
            .Where(d => !d.IsRefundDish)
            .Select(td =>
            {
                var dish = allDishes.FirstOrDefault(d => d.Id == td.DishId);
                if (dish == null)
                    return null;

                return new TopDishDtos(
                    td.DishId ?? Guid.Empty,
                    dish.DishGeneral.DishName,
                    dish.DishGeneral.DishDescription,
                    dish.Price,
                    dish.Status.ToString(),
                    td.TotalQuantity
                );
            })
            .Where(dto => dto != null) // Exclude null entries
            .Concat(allDishes
                .Where(d => !topDishes.Any(td => td.DishId == d.Id))
                .Select(d => new TopDishDtos(
                    d.Id,
                    d.DishGeneral.DishName,
                    d.DishGeneral.DishDescription,
                    d.Price,
                    d.Status.ToString(),
                    0
                )))
            .OrderByDescending(d => request.SortAscending ? d.Quantity : -d.Quantity)
            .Take(request.TopNDish)
            .ToList();


        var allRefundableDishDtos = refundDishInventory
            .Select(rdi => new TopRefundableDishDtos(
                rdi.DishId,
                rdi.Dish.DishGeneral.DishName,
                rdi.Dish.DishGeneral.DishDescription,
                rdi.Dish.Price,
                rdi.Dish.Status.ToString(),
                topDishes.FirstOrDefault(td => td.DishId == rdi.DishId)?.TotalQuantity ?? 0
            ))
            .OrderByDescending(d => request.SortAscending ? d.Quantity : -d.Quantity)
            .Take(request.TopNRefundableDish)
            .ToList();

        var allComboDtos = topCombos
            .Select(tc =>
            {
                var combo = allCombos.FirstOrDefault(c => c.Id == tc.ComboId);
                if (combo == null)
                    return null;

                return new GetTopComboDtos(
                    tc.ComboId ?? Guid.Empty,
                    combo.ComboName,
                    combo.Price,
                    combo.PercentReduce,
                    combo.Status.ToString(),
                    tc.TotalQuantity
                );
            })
            .Where(dto => dto != null) // Exclude null entries
            .Concat(allCombos
                .Where(c => !topCombos.Any(tc => tc.ComboId == c.Id))
                .Select(c => new GetTopComboDtos(
                    c.Id,
                    c.ComboName,
                    c.Price,
                    c.PercentReduce,
                    c.Status.ToString(),
                    0
                )))
            .OrderByDescending(c => request.SortAscending ? c.Quantity : -c.Quantity)
            .Take(request.TopNCombo)
            .ToList();


        return new GetTopUnpopularResponse(
            restaurant.Id,
            restaurant.RestaurantName,
            restaurant.Address,
            restaurant.RestaurantPhone,
            restaurant.Status.ToString(),
            allNormalDishDtos,
            allRefundableDishDtos,
            allComboDtos
        );
    }
}
