using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using StackExchange.Redis;

namespace FOV.Application.Features.Orders.Commands.CancelOrder;

public record CancelOrderCommand(Guid OrderId) : IRequest<Guid>;

public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IDatabase _database;
    public CancelOrderHandler(IUnitOfWorks unitOfWorks, IDatabase database)
    {
        _unitOfWorks = unitOfWorks;
        _database = database;
    }
    public async Task<Guid> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Order not found");

        foreach (var orderDetail in order.OrderDetails)
        {
            orderDetail.Status = OrderDetailsStatus.Canceled;
            _unitOfWorks.OrderDetailRepository.Update(orderDetail);

            if (orderDetail.ProductId.HasValue)
            {
                var dish = await _unitOfWorks.DishRepository.GetByIdAsync(orderDetail.ProductId.Value, d => d.DishIngredients);
                if (dish != null)
                {
                    foreach (var dishIngredient in dish.DishIngredients)
                    {
                        string ingredientLockKey = $"lock:ingredient:{dishIngredient.IngredientId}";
                        int lockedAmount = (int) dishIngredient.Quantity * orderDetail.Quantity;

                        await _database.StringDecrementAsync(ingredientLockKey, lockedAmount);
                    }
                }
            }
        }

        order.OrderStatus = OrderStatus.Canceled;
        _unitOfWorks.OrderRepository.Update(order);

        await _unitOfWorks.SaveChangeAsync();

        return order.Id;
    }
}
