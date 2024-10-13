using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.Caching.CachingService;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using StackExchange.Redis;

namespace FOV.Application.Features.Orders.Commands.CreateOrder;

public record OrderDetailDto(Guid? ComboId, Guid? ProductId, int Quantity)
{
    [JsonIgnore]
    public OrderDetailsStatus Status = OrderDetailsStatus.Prepare;
}
public record CreateOrderWithTableIdCommand(
    OrderType OrderType,
    DateTime OrderTime,
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
            throw new Exception("Không thể khóa bàn. Vui lòng thử lại sau.");
        }

        // Keep track of the original status of the table
        TableStatus originalTableStatus = TableStatus.Unknown;

        try
        {
            var table = await _unitOfWorks.TableRepository.GetByIdAsync(request.TableId);
            if (table == null)
            {
                throw new Exception($"Không tìm thấy bàn có ID {request.TableId}.");
            }

            originalTableStatus = table.TableStatus;

            if (table.TableStatus == TableStatus.Working)
            {
                throw new Exception("Bàn hiện không khả dụng để đặt hàng.");
            }

            table.TableStatus = TableStatus.Working;
            _unitOfWorks.TableRepository.Update(table);
            await _unitOfWorks.SaveChangeAsync();

            var tableOrders = (await _unitOfWorks.OrderRepository.GetAllAsync())
                .Where(o => o.TableId == request.TableId && o.OrderStatus != OrderStatus.Finish)
                .ToList();

            if (tableOrders.Any())
            {
                throw new Exception("Hiện đang có đơn hàng hoạt động tại bàn này.");
            }

            decimal totalPrice = 0;

            var order = new Domain.Entities.OrderAggregator.Order(request.OrderType, request.OrderTime, 0)
            {
                TableId = request.TableId,
                OrderStatus = request.OrderStatus,
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var detail in request.OrderDetails)
            {
                if (detail.ComboId.HasValue)
                {
                    var combo = await _unitOfWorks.ComboRepository.GetByIdAsync(detail.ComboId.Value);
                    if (combo == null)
                    {
                        throw new Exception($"Không tìm thấy combo có ID {detail.ComboId.Value}.");
                    }

                    var comboPrice = combo.Price;
                    totalPrice += comboPrice * detail.Quantity;

                    var comboOrderDetail = new OrderDetail(combo.Id, null, null, detail.Quantity, comboPrice)
                    {
                        Status = OrderDetailsStatus.Prepare
                    };
                    order.OrderDetails.Add(comboOrderDetail);

                    foreach (var dishCombo in combo.DishCombos)
                    {
                        totalPrice = await ProcessDish(dishCombo.DishId, detail.Quantity, lockService, order, totalPrice);
                    }
                }
                else if (detail.ProductId.HasValue)
                {
                    totalPrice = await ProcessDish(detail.ProductId.Value, detail.Quantity, lockService, order, totalPrice);
                }
            }

            order.TotalPrice = totalPrice;

            await _unitOfWorks.OrderRepository.AddAsync(order);
            await _unitOfWorks.SaveChangeAsync();
            await lockService.ReleaseLockAsync();

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
            throw new Exception($"Đã xảy ra lỗi khi đặt hàng: {ex.Message}");
        }
    }

    private async Task<decimal> ProcessDish(Guid productId, int quantity, LockingHandler lockService, Domain.Entities.OrderAggregator.Order order, decimal totalPrice)
    {
        var dishes = await _unitOfWorks.DishRepository.GetAllAsync(x => x.DishIngredients);
        var dish = dishes.FirstOrDefault(x => x.Id == productId);

        if (dish == null)
        {
            await lockService.ReleaseLockAsync();
            throw new Exception($"Không tìm thấy món ăn có ID {productId}.");
        }

        foreach (var dishIngredient in dish.DishIngredients)
        {
            string ingredientLockKey = $"lock:ingredient:{dishIngredient.IngredientId}";

            if (!await _database.LockTakeAsync(ingredientLockKey, order.TableId.ToString(), TimeSpan.FromSeconds(10)))
            {
                await lockService.ReleaseLockAsync();
                throw new Exception($"Không thể khóa nguyên liệu có ID: {dishIngredient.IngredientId}");
            }

            var ingredient = await _unitOfWorks.IngredientRepository.GetByIdAsync(dishIngredient.IngredientId);
            if (ingredient == null)
            {
                await lockService.ReleaseLockAsync();
                throw new Exception($"Không tìm thấy nguyên liệu có ID {dishIngredient.IngredientId}.");
            }

            var requiredAmount = dishIngredient.Quantity * quantity;

            var maxServings = ingredient.IngredientAmount / dishIngredient.Quantity;
            if (maxServings < quantity)
            {
                await lockService.ReleaseLockAsync();
                throw new Exception($"Chỉ có thể chuẩn bị {maxServings} phần {dish.DishGeneral.DishName} do không đủ nguyên liệu.");
            }

            if (ingredient.IngredientAmount < requiredAmount)
            {
                await lockService.ReleaseLockAsync();
                throw new Exception($"Nguyên liệu {ingredient.IngredientName} không đủ. Yêu cầu: {requiredAmount}, Có sẵn: {ingredient.IngredientAmount}");
            }

            ingredient.IngredientAmount -= requiredAmount;
            _unitOfWorks.IngredientRepository.Update(ingredient);

            await _database.LockReleaseAsync(ingredientLockKey, order.TableId.ToString());
        }

        var dishPrice = dish.Price ?? 0;
        totalPrice += dishPrice * quantity;

        var orderDetail = new OrderDetail(null, productId, null, quantity, dishPrice)
        {
            Status = OrderDetailsStatus.Prepare
        };
        order.OrderDetails.Add(orderDetail);

        return totalPrice;
    }
}
