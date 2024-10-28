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
using FOV.Infrastructure.Caching.CachingService;
using FOV.Infrastructure.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using StackExchange.Redis;

namespace FOV.Application.Features.Orders.Commands.CreateOrder;

public record OrderDetailDto(Guid? ComboId, Guid? ProductId, int Quantity, string? Note)
{
    [JsonIgnore]
    public readonly OrderDetailsStatus Status = OrderDetailsStatus.Prepare;
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

    public CreateOrderHandler(IUnitOfWorks unitOfWorks, IDatabase database, OrderHub orderHub)
    {
        _unitOfWorks = unitOfWorks;
        _database = database;
        _lockHandlers = new ConcurrentDictionary<string, LockingHandler>();
        _orderHub = orderHub;
    }

    public async Task<Guid> Handle(CreateOrderWithTableIdCommand request, CancellationToken cancellationToken)
    {
        string lockKey = $"lock:table:{request.TableId}";
        LockingHandler lockService;
        var fieldErrors = new List<FieldError>();

        if (!_lockHandlers.TryGetValue(lockKey, out lockService))
        {
            lockService = new LockingHandler(_database, lockKey, TimeSpan.FromSeconds(10));
            _lockHandlers.TryAdd(lockKey, lockService);
        }

        if (!await lockService.AcquireLockAsync())
        {
            fieldErrors.Add(new FieldError { Field = "lock", Message = "Không thể khóa bàn. Vui lòng thử lại sau." });
        }

        TableStatus originalTableStatus = TableStatus.Available;

        try
        {
            var table = await _unitOfWorks.TableRepository.GetByIdAsync(request.TableId);
            if (table == null)
            {
                fieldErrors.Add(new FieldError { Field = "tableId", Message = $"Không tìm thấy bàn có ID {request.TableId}." });
            }
            else
            {
                if (!table.IsLogin)
                {
                    fieldErrors.Add(new FieldError { Field = "isLogin", Message = "Bàn chưa đăng nhập. Không thể đặt hàng." });
                }

                if (table.TableStatus == TableStatus.Working)
                {
                    fieldErrors.Add(new FieldError { Field = "tableStatus", Message = "Bàn hiện không khả dụng để đặt hàng." });
                }

                var tableOrders = (await _unitOfWorks.OrderRepository.GetAllAsync())
                    .Where(o => o.TableId == request.TableId && o.OrderStatus != OrderStatus.Finish)
                    .ToList();

                if (tableOrders.Any())
                {
                    fieldErrors.Add(new FieldError { Field = "tableId", Message = "Hiện đang có đơn hàng hoạt động tại bàn này." });
                }
            }

            if (fieldErrors.Any())
            {
                throw new AppException("Lỗi khi tạo đơn hàng mới", fieldErrors, 400);
            }

            originalTableStatus = table.TableStatus;
            table.TableStatus = TableStatus.Working;

            _unitOfWorks.TableRepository.Update(table);
            await _unitOfWorks.SaveChangeAsync();

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
                        fieldErrors.Add(new FieldError { Field = "comboId", Message = "Không có combo này trong hệ thống." });
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

            await _unitOfWorks.OrderRepository.AddAsync(order);
            await _unitOfWorks.SaveChangeAsync();
            await lockService.ReleaseLockAsync();

            //test, remove when deploy
            await _orderHub.SendOrder(order.Id);

            return order.Id;
        }
        catch (Exception ex)
        {
            var table = await _unitOfWorks.TableRepository.GetByIdAsync(request.TableId);
            if (table != null)
            {
                table.TableStatus = originalTableStatus;
                _unitOfWorks.TableRepository.Update(table);
                await _unitOfWorks.SaveChangeAsync();
            }

            await lockService.ReleaseLockAsync();
            if (ex is AppException appEx)
            {
                throw appEx;
            }
            else
            {
                throw new AppException("Đã xảy ra lỗi khi đặt hàng", new List<string> { ex.Message }, ex);
            }
        }
    }
    private async Task<decimal> ProcessDish(Guid productId, int quantity, string note, LockingHandler lockService, Domain.Entities.OrderAggregator.Order order, decimal totalPrice, bool isCombo)
    {
        var fieldErrors = new List<FieldError>();
        var dishes = await _unitOfWorks.DishRepository.GetAllAsync(x => x.DishIngredients, x => x.DishGeneral);
        var dish = dishes.FirstOrDefault(x => x.Id == productId);

        if (dish == null)
        {
            await lockService.ReleaseLockAsync();
            fieldErrors.Add(new FieldError { Field = "productId", Message = "Không tìm thấy món ăn" });
        }

        foreach (var dishIngredient in dish.DishIngredients)
        {
            string ingredientLockKey = $"lock:ingredient:{dishIngredient.IngredientId}";
            var requiredAmount = dishIngredient.Quantity * quantity;

            var lockedAmount = (int)(await _database.StringGetAsync(ingredientLockKey));
            var ingredient = await _unitOfWorks.IngredientRepository.GetByIdAsync(dishIngredient.IngredientId);
            var availableAmount = ingredient.IngredientAmount - lockedAmount;

            if (availableAmount < requiredAmount)
            {
                await lockService.ReleaseLockAsync();
                throw new Exception($"Không đủ nguyên liệu {ingredient.IngredientName}. Có sẵn: {availableAmount}");
            }

            await _database.StringSetAsync(ingredientLockKey, (long)(lockedAmount + requiredAmount));
        }

        var dishPrice = dish.Price ?? 0;
        if (!isCombo)
        {
            totalPrice += dishPrice * quantity;
        }

        if (!isCombo)
        {
            var orderDetail = new OrderDetail(null, productId, null, quantity, dishPrice, note)
            {
                Status = OrderDetailsStatus.Prepare,
                IsRefund = dish.DishGeneral.IsRefund
            };
            order.OrderDetails.Add(orderDetail);
        }

        return totalPrice;
    }
}
