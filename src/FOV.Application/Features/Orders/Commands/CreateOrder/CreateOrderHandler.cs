using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Caching.CachingService;
using FOV.Infrastructure.FCM;
using FOV.Infrastructure.FirebaseDB;
using FOV.Infrastructure.Notifications.Web.SignalR.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace FOV.Application.Features.Orders.Commands.CreateOrder;

public record OrderDetailDto(Guid? ComboId, Guid? ProductId, int Quantity, string? Note)
{
    [JsonIgnore]
    public readonly OrderDetailsStatus Status = OrderDetailsStatus.Prepare;
    public bool IsAddMore = false;
}

public record CreateOrderWithTableIdCommand(
    List<OrderDetailDto> OrderDetails
) : IRequest<Guid>
{
    [JsonIgnore]
    public readonly OrderStatus OrderStatus = OrderStatus.Prepare;
    [JsonIgnore]
    public Guid TableId { get; set; }
}

public class CreateOrderHandler : IRequestHandler<CreateOrderWithTableIdCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IDatabase _database;
    private readonly OrderHub _orderHub;
    private readonly ConcurrentDictionary<string, LockingHandler> _lockHandlers;
    private readonly UserManager<User> _userManager;

    public CreateOrderHandler(IUnitOfWorks unitOfWorks, IDatabase database, OrderHub orderHub, UserManager<User> userManager)
    {
        _unitOfWorks = unitOfWorks;
        _database = database;
        _lockHandlers = new ConcurrentDictionary<string, LockingHandler>();
        _orderHub = orderHub;
        _userManager = userManager;
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
            throw new AppException("Không thể khóa bàn. Vui lòng thử lại sau.");
        }

        if (request.OrderDetails == null || !request.OrderDetails.Any())
        {
            await lockService.ReleaseLockAsync();
            throw new AppException("Danh sách món ăn không được để trống.");
        }

        TableStatus originalTableStatus = TableStatus.Available;

        try
        {
            var table = await _unitOfWorks.TableRepository.GetByIdAsync(request.TableId, x => x.Restaurant);
            if (table == null)
            {
                throw new AppException($"Không tìm thấy bàn có ID {request.TableId}.");
            }
            else
            {
                if (!table.IsLogin)
                {
                    throw new AppException("Bàn chưa đăng nhập. Không thể đặt hàng.");
                }

                if (table.TableStatus == TableStatus.Working)
                {
                    throw new AppException("Bàn hiện không khả dụng để đặt hàng.");
                }

                var tableOrders = (await _unitOfWorks.OrderRepository.GetAllAsync())
                    .Where(o => o.TableId == request.TableId && o.OrderStatus != OrderStatus.Finish && o.OrderStatus != OrderStatus.Canceled)
                    .ToList();

                if (tableOrders.Any())
                {
                    throw new AppException("Hiện đang có đơn hàng hoạt động tại bàn này.");
                }
            }

            foreach (var detail in request.OrderDetails)
            {
                if (detail.Quantity <= 0)
                {
                    throw new AppException("Số lượng phải lớn hơn hoặc bằng 0.");
                }
            }

            originalTableStatus = table.TableStatus;
            table.TableStatus = TableStatus.Working;

            decimal totalPrice = 0;

            var order = new Domain.Entities.OrderAggregator.Order(DateTime.UtcNow, 0)
            {
                TableId = request.TableId,
                OrderStatus = request.OrderStatus,
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var detail in request.OrderDetails)
            {
                if (detail.ComboId.HasValue)
                {
                    var combo = await _unitOfWorks.ComboRepository.GetByIdAsync(detail.ComboId.Value, x => x.DishCombos);
                    if (combo == null)
                    {
                        throw new AppException("Không có combo này trong hệ thống.");
                    }

                    var comboPrice = combo.Price;
                    totalPrice += comboPrice * detail.Quantity;

                    var comboOrderDetail = new OrderDetail(combo.Id, null, null, detail.Quantity, comboPrice, detail.Note)
                    {
                        Status = OrderDetailsStatus.Prepare
                    };
                    order.OrderDetails.Add(comboOrderDetail);

                    foreach (var dishCombo in combo.DishCombos)
                    {
                        totalPrice = await ProcessDish(dishCombo.DishId, detail.Quantity, detail.Note, lockService, order, totalPrice, isCombo: true);
                    }
                }
                else if (detail.ProductId.HasValue)
                {
                    totalPrice = await ProcessDish(detail.ProductId.Value, detail.Quantity, detail.Note, lockService, order, totalPrice, isCombo: false);
                }
            }

            order.TotalPrice = totalPrice;

            _unitOfWorks.TableRepository.Update(table);
            await _unitOfWorks.OrderRepository.AddAsync(order);
            await _unitOfWorks.SaveChangeAsync();
            await lockService.ReleaseLockAsync();

            var restaurantId = table.Restaurant.Id;
            var userInRestaurantAlreadyCheckAttendance = _userManager.Users
                .Where(x => x.RestaurantId == restaurantId &&
                            x.WaiterSchedules.Any(ws =>
                                ws.Attendances.Any(a =>
                                    a.CheckInTime != null &&
                                    a.CheckOutTime == null &&
                                    ws.DateTime == DateOnly.FromDateTime(DateTime.Now.AddHours(7)))))
                .Include(x => x.WaiterSchedules)
                    .ThenInclude(ws => ws.Attendances)
                .ToList();

            foreach (var eachUserInRestaurantAlreadyCheckAttendance in userInRestaurantAlreadyCheckAttendance)
            {
                var tokenUser = FCMTokenHandler.GetFCMToken(eachUserInRestaurantAlreadyCheckAttendance.Id).ToString();
                if (!string.IsNullOrEmpty(tokenUser))
                {
                    CloudMessagingHandlers.SendNotification(tokenUser, $"Có đơn hàng mới", $"Có đơn hàng mới tại bàn {table.TableNumber}");
                };
            }

            //test, remove when deploy
            await _orderHub.SendOrder(order.Id);

            return order.Id;
        }
        catch (AppException ex)
        {
            var table = await _unitOfWorks.TableRepository.GetByIdAsync(request.TableId);
            if (table != null)
            {
                table.TableStatus = originalTableStatus;
                _unitOfWorks.TableRepository.Update(table);
                await _unitOfWorks.SaveChangeAsync();
            }

            await lockService.ReleaseLockAsync();
            throw new AppException(ex.Message);
        }
    }
    private async Task<decimal> ProcessDish(Guid productId, int quantity, string note, LockingHandler lockService, Domain.Entities.OrderAggregator.Order order, decimal totalPrice, bool isCombo)
    {
        var fieldErrors = new List<FieldError>();
        var lockedIngredientKeys = new List<string>(); // Track locked ingredients for cleanup

        try
        {
            var dishes = await _unitOfWorks.DishRepository.GetAllAsync(
                x => x.DishIngredients,
                x => x.DishGeneral,
                x => x.RefundDishInventory,
                x => x.DishCombos
            );

            var dish = dishes.FirstOrDefault(x => x.Id == productId);
            if (dish == null)
            {
                throw new AppException("Không tìm thấy món ăn");
            }

            var dishPrice = dish.Price ?? 0;
            if (dish.DishGeneral.IsRefund)
            {
                if (dish.RefundDishInventory.QuantityAvailable < quantity)
                {
                    throw new AppException($"Không đủ món ăn '{dish.DishGeneral.DishName}' trong kho. Chỉ còn lại: '{dish.RefundDishInventory.QuantityAvailable}'");
                }
                //dish.Price += dishPrice * quantity;
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
                        if (combo != null)
                        {
                            throw new AppException($"Combo '{combo.ComboName}' hiện tại chỉ có thể đặt tối đa {maxDishes} phần do hạn chế về nguyên liệu.");
                        }
                    }
                    else
                    {
                        throw new AppException($"Món ăn '{dish.DishGeneral.DishName}' này hiện tại chỉ có thể đặt tối đa {maxDishes} phần do hạn chế về nguyên liệu.");
                    }
                }

                await _database.StringSetAsync(ingredientLockKey, (long)(lockedAmount + requiredAmount));
            }

            if (dish.DishGeneral.IsRefund)
            {
                dish.RefundDishInventory.QuantityAvailable -= quantity;
                _unitOfWorks.DishRepository.Update(dish);
                await _unitOfWorks.SaveChangeAsync();
            }

            if (!isCombo)
            {
                totalPrice += dishPrice * quantity;

                var orderDetail = new OrderDetail(null, productId, null, quantity, dishPrice, note)
                {
                    Status = OrderDetailsStatus.Prepare,
                    IsRefund = dish.DishGeneral.IsRefund,
                    IsAddMore = false
                };
                order.OrderDetails.Add(orderDetail);
            }

            return totalPrice;
        }
        catch (Exception)
        {
            foreach (var lockKey in lockedIngredientKeys)
            {
                var currentLock = await _database.StringGetAsync(lockKey);
                if (currentLock.HasValue)
                {
                    await _database.StringSetAsync(lockKey, 0);
                }
            }
            await lockService.ReleaseLockAsync();
            throw;
        }
    }

}
