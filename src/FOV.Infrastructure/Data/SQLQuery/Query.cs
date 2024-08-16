using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Order.Queries;
public record GetOrderCommand(Guid? Id, string? OrderStatus, string? OrderType, DateTime? OrderTime, decimal? TotalPrice, Guid? TableId) : IRequest<List<GetOrderResponse>>;
public record GetOrderResponse(Guid Id, string OrderStatus, string OrderType, DateTime OrderTime, decimal TotalPrice, Guid TableId);
public class GetOrderQueryHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetOrderCommand, List<GetOrderResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetOrderResponse>> Handle(GetOrderCommand request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWorks.OrderRepository.GetAllAsync();
        var filterEntity = new FOV.Domain.Entities.OrderAggregator.Order
        {
            Id = request.Id ?? Guid.Empty,
            OrderStatus = string.IsNullOrEmpty(request.OrderStatus) ? null : request.OrderStatus,
            OrderType = string.IsNullOrEmpty(request.OrderType) ? null : request.OrderType,
            OrderTime = request.OrderTime ?? DateTime.MinValue,
            TotalPrice = request.TotalPrice ?? 0,
            TableId = request.TableId ?? Guid.Empty
        };
        var filterOrders = orders.AsQueryable().CustomFilterV1(filterEntity);
        return [.. filterOrders.Select(o => new GetOrderResponse(
                o.Id,
                o.OrderStatus ?? string.Empty,
                o.OrderType ?? string.Empty,
                o.OrderTime ?? DateTime.MinValue,
                o.TotalPrice ?? 0,
                o.TableId))];
    }
}
