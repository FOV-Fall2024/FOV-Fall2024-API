using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.Caching.CachingService;
using FOV.Infrastructure.Notifications.Web.SignalR.Notification.Setup;
using FOV.Infrastructure.Notifications.Web.SignalR.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using StackExchange.Redis;

namespace FOV.Application.Features.Orders.Commands.AddProduct;

public record AddProductsToOrdersCommand(List<GetOrderDetailDto> AdditionalOrderDetails) : IRequest<Guid>
{
    [JsonIgnore]
    public Guid OrderId { get; set; }
}
public record AddProductsToOrdersResult(Guid OrderId);

public record GetOrderDetailDto(Guid? ComboId, Guid? ProductId, int Quantity, string? Note)
{
    [JsonIgnore]
    public readonly OrderDetailsStatus Status = OrderDetailsStatus.Prepare;
    [JsonIgnore]
    public bool IsAddMore = false;
}

public class AddProductsToOrderHandler : IRequestHandler<AddProductsToOrdersCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IDatabase _database;
    private readonly OrderHub _orderHub;
    private readonly NotificationHub _notificationHub;
    private readonly ConcurrentDictionary<string, LockingHandler> _lockHandlers;

    public AddProductsToOrderHandler(IUnitOfWorks unitOfWorks, IDatabase database, OrderHub orderHub, NotificationHub notificationHub)
    {
        _unitOfWorks = unitOfWorks;
        _database = database;
        _orderHub = orderHub;
        _notificationHub = notificationHub;
        _lockHandlers = new ConcurrentDictionary<string, LockingHandler>();
    }

    public async Task<Guid> Handle(AddProductsToOrdersCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails);
        if (order == null)
        {
            throw new AppException("Order not found", new List<string> { "Invalid order ID" });
        }

        order.OrderStatus = OrderStatus.Prepare;

        string lockKey = $"lock:table:{order.TableId}";
        LockingHandler lockService = _lockHandlers.GetOrAdd(lockKey, _ => new LockingHandler(_database, lockKey, TimeSpan.FromSeconds(10)));

        if (!await lockService.AcquireLockAsync())
        {
            throw new AppException("Could not acquire lock on the table.");
        }

        try
        {
            decimal totalPrice = order.TotalPrice;

            foreach (var detail in request.AdditionalOrderDetails)
            {
                if (detail.ComboId.HasValue)
                {
                    var combo = await _unitOfWorks.ComboRepository.GetByIdAsync(detail.ComboId.Value, x => x.DishCombos);
                    if (combo == null)
                    {
                        throw new AppException("Combo not found in the system");
                    }

                    decimal comboPrice = combo.Price;
                    totalPrice += comboPrice * detail.Quantity;
                    order.OrderDetails.Add(new OrderDetail(combo.Id, null, null, detail.Quantity, comboPrice, detail.Note)
                    {
                        Status = OrderDetailsStatus.Prepare,
                        IsAddMore = true
                    });

                    foreach (var dishCombo in combo.DishCombos)
                    {
                        totalPrice = await ProcessDish(dishCombo.DishId, detail.Quantity, detail.Note, lockService, order, totalPrice, true);
                    }
                }
                else if (detail.ProductId.HasValue)
                {
                    totalPrice = await ProcessDish(detail.ProductId.Value, detail.Quantity, detail.Note, lockService, order, totalPrice, false);
                }
            }

            order.TotalPrice = totalPrice;

            _unitOfWorks.OrderRepository.Update(order);
            await _unitOfWorks.SaveChangeAsync();

            await _orderHub.UpdateOrderStatus(order.Id, "Prepare");
            //await _notificationHub.SendNotificationToWaiter(order.UserId ?? Guid.Empty, order.Id, order.OrderDetails.First().Id);

            return order.Id;
        }
        finally
        {
            await lockService.ReleaseLockAsync();
        }
    }

    public async Task<decimal> ProcessDish(Guid productId, int quantity, string note, LockingHandler lockService, Domain.Entities.OrderAggregator.Order order, decimal totalPrice, bool isCombo)
    {
        var lockedIngredientKeys = new List<string>(); // Track locked ingredients for cleanup
        var dish = await _unitOfWorks.DishRepository.GetByIdAsync(productId, x => x.DishIngredients, x => x.DishGeneral, x => x.RefundDishInventory);

        if (request.AdditionalOrderDetails == null || !request.AdditionalOrderDetails.Any())
        {
            throw new AppException("Danh sách món ăn bổ sung không được để trống.");
        }

        if (dish == null)
        {
            await lockService.ReleaseLockAsync();
            throw new AppException("Không tìm thấy món ăn");
        }

        if (dish.DishGeneral.IsRefund && dish.RefundDishInventory != null)
        {
            if (quantity > dish.RefundDishInventory.QuantityAvailable)
            {
                await lockService.ReleaseLockAsync();
                throw new AppException($"Không đủ món {dish.DishGeneral.DishName}. Tối đa còn: {dish.RefundDishInventory.QuantityAvailable} phần");
            }

            dish.RefundDishInventory.QuantityAvailable -= quantity;
            _unitOfWorks.DishRepository.Update(dish);
        }

        foreach (var dishIngredient in dish.DishIngredients)
        {
            string ingredientLockKey = $"lock:ingredient:{dishIngredient.IngredientId}";
            lockedIngredientKeys.Add(ingredientLockKey);

            var requiredAmount = dishIngredient.Quantity * quantity;
            var lockedAmount = (int)(await _database.StringGetAsync(ingredientLockKey));
            var ingredient = await _unitOfWorks.IngredientRepository.GetByIdAsync(dishIngredient.IngredientId);
            var availableAmount = ingredient.IngredientAmount - lockedAmount;

            int maxDishes = (int)(availableAmount / dishIngredient.Quantity);

            if (availableAmount < requiredAmount)
            {
                if (isCombo)
                {
                    var combo = dish.DishCombos.FirstOrDefault()?.Combo;
                    throw new AppException($"Combo '{combo.ComboName}' hiện tại chỉ có thể đặt tối đa {maxDishes} phần do hạn chế về nguyên liệu.");
                }
                else
                {
                    throw new AppException($"Món ăn '{dish.DishGeneral.DishName}' này hiện tại chỉ có thể đặt tối đa {maxDishes} phần.");
                }
            }

            await _database.StringSetAsync(ingredientLockKey, (long)(lockedAmount + requiredAmount));
        }

        decimal dishPrice = dish.Price ?? 0;
        if (!isCombo)
        {
            totalPrice += dishPrice * quantity;
            var orderDetail = new OrderDetail(null, productId, null, quantity, dishPrice, note)
            {
                Status = OrderDetailsStatus.Prepare,
                IsRefund = dish.DishGeneral.IsRefund,
                IsAddMore = true
            };
            order.OrderDetails.Add(orderDetail);
        }

        return totalPrice;
    }
}
