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
using FOV.Infrastructure.Order.Setup;
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

public record GetOrderDetailDto(Guid? ComboId, Guid? ProductId, int Quantity, string Note)
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
    private readonly ConcurrentDictionary<string, LockingHandler> _lockHandlers;

    public AddProductsToOrderHandler(IUnitOfWorks unitOfWorks, IDatabase database, OrderHub orderHub)
    {
        _unitOfWorks = unitOfWorks;
        _database = database;
        _orderHub = orderHub;
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
                        Status = OrderDetailsStatus.Prepare
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

            await _orderHub.SendOrder(order.Id);

            return order.Id;
        }
        finally
        {
            await lockService.ReleaseLockAsync();
        }
    }

    public async Task<decimal> ProcessDish(Guid productId, int quantity, string note, LockingHandler lockService, Domain.Entities.OrderAggregator.Order order, decimal totalPrice, bool isCombo)
    {
        var fieldErrors = new List<FieldError>();
        var lockedIngredientKeys = new List<string>(); // Track locked ingredients for cleanup
        var dish = await _unitOfWorks.DishRepository.GetByIdAsync(productId, x => x.DishIngredients, x => x.DishGeneral, x => x.RefundDishInventory);

        if (dish == null)
        {
            await lockService.ReleaseLockAsync();
            fieldErrors.Add(new FieldError { Field = "productId", Message = "Dish not found" });
            throw new AppException("Dish not found", fieldErrors);
        }

        if (dish.DishGeneral.IsRefund && dish.RefundDishInventory != null)
        {
            if (quantity > dish.RefundDishInventory.QuantityAvailable)
            {
                await lockService.ReleaseLockAsync();
                throw new Exception($"Không đủ món {dish.DishGeneral.DishName}. Tối đa còn: {dish.RefundDishInventory.QuantityAvailable} phần");
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
                    fieldErrors.Add(new FieldError
                    {
                        Field = "comboId",
                        Message = combo != null
                            ? $"Combo '{combo.ComboName}' hiện tại chỉ có thể đặt tối đa {maxDishes} phần do hạn chế về nguyên liệu."
                            : $"Món ăn này hiện tại chỉ có thể đặt tối đa {maxDishes} phần."
                    });
                }
                else
                {
                    fieldErrors.Add(new FieldError
                    {
                        Field = "productId",
                        Message = $"Món ăn này hiện tại chỉ có thể đặt tối đa {maxDishes} phần."
                    });
                }
                throw new AppException("Không đủ nguyên liệu", fieldErrors, 400);
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
