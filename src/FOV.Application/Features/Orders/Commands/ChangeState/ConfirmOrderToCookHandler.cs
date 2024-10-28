using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using StackExchange.Redis;

namespace FOV.Application.Features.Orders.Commands.ChangeStateOrder;
public record ConfirmOrderToCookCommand(Guid OrderId) : IRequest<Guid>;
public class ConfirmOrderToCookHandler : IRequestHandler<ConfirmOrderToCookCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IDatabase _database;
    private readonly OrderHub _orderHub;
    public ConfirmOrderToCookHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub, IDatabase database)
    {
        _unitOfWorks = unitOfWorks;
        _orderHub = orderHub;
        _database = database;
    }
    public async Task<Guid> Handle(ConfirmOrderToCookCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Order not found");

        order.OrderStatus = OrderStatus.Cook;

        foreach (var detail in order.OrderDetails)
        {
            detail.Status = OrderDetailsStatus.Cook;

            if (detail.ProductId.HasValue)
            {
                await ProcessDishIngredients(detail.ProductId.Value, detail.Quantity);
            }
            else if (detail.ComboId.HasValue)
            {
                var combo = await _unitOfWorks.ComboRepository.GetByIdAsync(detail.ComboId.Value, c => c.DishCombos);
                if (combo != null)
                {
                    foreach (var dishCombo in combo.DishCombos)
                    {
                        await ProcessDishIngredients(dishCombo.DishId, detail.Quantity);
                    }
                }
            }
        }

        _unitOfWorks.OrderRepository.Update(order);
        await _unitOfWorks.SaveChangeAsync();
        await _orderHub.UpdateOrderStatus(order.Id, order.OrderStatus.ToString());

        return order.Id;
    }

    private async Task ProcessDishIngredients(Guid dishId, int quantity)
    {
        var dish = await _unitOfWorks.DishRepository.GetByIdAsync(dishId, d => d.DishIngredients);
        if (dish == null) throw new Exception("Dish not found");

        foreach (var dishIngredient in dish.DishIngredients)
        {
            var ingredient = await _unitOfWorks.IngredientRepository.GetByIdAsync(dishIngredient.IngredientId);
            if (ingredient == null) throw new Exception("Ingredient not found");

            var requiredAmount = dishIngredient.Quantity * quantity;
            if (ingredient.IngredientAmount < requiredAmount)
                throw new Exception($"Not enough of ingredient {ingredient.IngredientName}");

            ingredient.IngredientAmount -= requiredAmount;
            _unitOfWorks.IngredientRepository.Update(ingredient);
        }
    }

}
