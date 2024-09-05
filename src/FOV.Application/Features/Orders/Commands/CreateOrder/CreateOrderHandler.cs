using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.Caching.CachingService;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using StackExchange.Redis;

namespace FOV.Application.Features.Orders.Commands.CreateOrder;

public record OrderDetailDto(Guid? ComboId, Guid? ProductId, int Quantity, decimal Price)
{
    [JsonIgnore]
    public OrderDetailsStatus Status = OrderDetailsStatus.Prepare;
}
public record CreateOrderWithTableIdCommand(
    OrderType OrderType,
    DateTime OrderTime,
    decimal TotalPrice,
    List<OrderDetailDto> OrderDetails
) : IRequest<Guid>
{
    [JsonIgnore]
    public OrderStatus OrderStatus = OrderStatus.Prepare;
    [JsonIgnore]
    public Guid TableId { get; set; }
}

public class CreateOrderHandler : IRequestHandler<CreateOrderWithTableIdCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IDatabase _database;
    private readonly ConcurrentDictionary<string, LockingHandler> _lockHandlers;

    public CreateOrderHandler(IUnitOfWorks unitOfWorks, IDatabase database)
    {
        _unitOfWorks = unitOfWorks;
        _database = database;
        _lockHandlers = new ConcurrentDictionary<string, LockingHandler>();
    }

    public async Task<Guid> Handle(CreateOrderWithTableIdCommand request, CancellationToken cancellationToken)
    {
        string lockKey = $"lock:table:{request.TableId}";
        LockingHandler lockService;

        if (!_lockHandlers.TryGetValue(lockKey, out lockService))
        {
            lockService = new LockingHandler(_database, lockKey, TimeSpan.FromSeconds(10));
            _lockHandlers.TryAdd(lockKey, lockService);
        }

        if (!await lockService.AcquireLockAsync())
        {
            throw new Exception("Failed to acquire lock for the table. Try again later.");
        }

        var orders = await _unitOfWorks.OrderRepository.GetAllAsync();
        var tableOrders = orders.Where(o => o.TableId == request.TableId).ToList();

        if (tableOrders.Any(o => o.OrderStatus != OrderStatus.Finish))
        {
            await lockService.ReleaseLockAsync();
            throw new Exception("Cannot create a new order. The table is occupied by an order that is not yet finished.");
        }

        var order = new Domain.Entities.OrderAggregator.Order(request.OrderType, request.OrderTime, request.TotalPrice)
        {
            TableId = request.TableId,
            OrderStatus = request.OrderStatus,
            OrderDetails = new List<OrderDetail>()
        };

        foreach (var detail in request.OrderDetails)
        {
            var orderDetail = new OrderDetail(
                detail.ComboId,
                detail.ProductId,
                null,
                detail.Quantity,
                detail.Price
            )
            {
                Status = detail.Status
            };

            order.OrderDetails.Add(orderDetail);
        }

        await _unitOfWorks.OrderRepository.AddAsync(order);
        await _unitOfWorks.SaveChangeAsync();

        if (request.OrderStatus == OrderStatus.Finish)
        {
            await lockService.ReleaseLockAsync();
        }

        return order.Id;
    }
}
