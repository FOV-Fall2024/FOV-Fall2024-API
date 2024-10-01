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
            throw new Exception("Cannot place an order at this time. There is an active order at this table.");
        }

        var order = new Domain.Entities.OrderAggregator.Order(request.OrderType, request.OrderTime, request.TotalPrice)
        {
            TableId = request.TableId,
            OrderStatus = request.OrderStatus,
            OrderDetails = new List<OrderDetail>()
        };

        foreach (var detail in request.OrderDetails)
        {
            if (detail.ComboId.HasValue)
            {
                // Process Combo
                var combo = await _unitOfWorks.ComboRepository.GetByIdAsync(detail.ComboId.Value);
                if (combo == null)
                {
                    await lockService.ReleaseLockAsync();
                    throw new Exception($"Combo with ID {detail.ComboId.Value} not found.");
                }

                foreach (var dishCombo in combo.DishCombos)
                {
                    await ProcessDish(dishCombo.DishId, detail.Quantity, detail.Price, lockService, order);
                }
            }
            else if (detail.ProductId.HasValue)
            {
                // Process Dish
                await ProcessDish(detail.ProductId.Value, detail.Quantity, detail.Price, lockService, order);
            }
        }

        await _unitOfWorks.OrderRepository.AddAsync(order);
        await _unitOfWorks.SaveChangeAsync();

        await lockService.ReleaseLockAsync();

        return order.Id;
    }

    private async Task ProcessDish(Guid productId, int quantity, decimal price, LockingHandler lockService, Domain.Entities.OrderAggregator.Order order)
    {
        var dish = await _unitOfWorks.DishRepository.GetByIdAsync(productId);
        if (dish == null)
        {
            await lockService.ReleaseLockAsync();
            throw new Exception($"Dish with ID {productId} not found.");
        }

        foreach (var dishIngredient in dish.DishIngredients)
        {
            string ingredientLockKey = $"lock:ingredient:{dishIngredient.IngredientId}";

            if (!await _database.LockTakeAsync(ingredientLockKey, order.TableId.ToString(), TimeSpan.FromSeconds(10)))
            {
                await lockService.ReleaseLockAsync();
                throw new Exception($"Failed to acquire lock for ingredient ID: {dishIngredient.IngredientId}");
            }

            var ingredient = await _unitOfWorks.IngredientRepository.GetByIdAsync(dishIngredient.IngredientId);
            if (ingredient == null)
            {
                await lockService.ReleaseLockAsync();
                throw new Exception($"Ingredient with ID {dishIngredient.IngredientId} not found.");
            }

            var requiredAmount = dishIngredient.Quantity * quantity;

            if (ingredient.IngredientAmount < requiredAmount)
            {
                await lockService.ReleaseLockAsync();
                throw new Exception($"Insufficient stock for ingredient {ingredient.IngredientName}. Required: {requiredAmount}, Available: {ingredient.IngredientAmount}");
            }

            ingredient.IngredientAmount -= requiredAmount;
            _unitOfWorks.IngredientRepository.Update(ingredient);

            await _database.LockReleaseAsync(ingredientLockKey, order.TableId.ToString());
        }

        var orderDetail = new OrderDetail(null, productId, null, quantity, price)
        {
            Status = OrderDetailsStatus.Prepare
        };
        order.OrderDetails.Add(orderDetail);
    }
}
