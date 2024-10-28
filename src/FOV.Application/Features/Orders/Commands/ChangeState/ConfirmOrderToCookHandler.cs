using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using StackExchange.Redis;

namespace FOV.Application.Features.Orders.Commands.ChangeStateOrder
{
    public record ConfirmOrderToCookCommand(Guid OrderId) : IRequest<Guid>;

    public class ConfirmOrderToCookHandler : IRequestHandler<ConfirmOrderToCookCommand, Guid>
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly OrderHub _orderHub;
        private readonly IDatabase _database;

        public ConfirmOrderToCookHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub, IConnectionMultiplexer redis)
        {
            _unitOfWorks = unitOfWorks;
            _orderHub = orderHub;
            _database = redis.GetDatabase();
        }

        public async Task<Guid> Handle(ConfirmOrderToCookCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
                ?? throw new Exception("Order not found");

            order.OrderStatus = OrderStatus.Cook;

            var ingredientUpdates = new Dictionary<Guid, int>();

            foreach (var detail in order.OrderDetails)
            {
                detail.Status = OrderDetailsStatus.Cook;

                if (detail.ProductId != null)
                {
                    await ReduceDishIngredients((Guid)detail.ProductId, detail.Quantity, ingredientUpdates);
                }
                else if (detail.ComboId != null)
                {
                    await ReduceComboIngredients((Guid)detail.ComboId, detail.Quantity, ingredientUpdates);
                }
            }

            await UpdateIngredients(ingredientUpdates);

            _unitOfWorks.OrderRepository.Update(order);
            await _unitOfWorks.SaveChangeAsync();
            await _orderHub.UpdateOrderStatus(order.Id, order.OrderStatus.ToString());

            return order.Id;
        }

        private async Task ReduceDishIngredients(Guid dishId, int quantity, Dictionary<Guid, int> ingredientUpdates)
        {
            var dish = await _unitOfWorks.DishRepository.GetByIdAsync(dishId, d => d.DishIngredients);
            if (dish == null) throw new Exception("Dish not found");

            foreach (var dishIngredient in dish.DishIngredients)
            {
                var ingredientId = dishIngredient.IngredientId;
                var requiredAmount = dishIngredient.Quantity * quantity;
                var lockKey = $"lock:ingredient:{ingredientId}";

                var currentLocked = await _database.StringGetAsync(lockKey);
                var lockedAmount = currentLocked.HasValue ? (int)currentLocked : 0;

                if (lockedAmount >= requiredAmount)
                {
                    if (ingredientUpdates.ContainsKey(ingredientId))
                    {
                        ingredientUpdates[ingredientId] += (int)requiredAmount;
                    }
                    else
                    {
                        ingredientUpdates[ingredientId] = (int)requiredAmount;
                    }

                    await _database.StringSetAsync(lockKey, (long)(lockedAmount - requiredAmount));
                }
                else
                {
                    throw new Exception($"Insufficient locked ingredient amount of {lockKey}. Required: {requiredAmount}, Locked: {lockedAmount}");
                }
            }
        }

        private async Task ReduceComboIngredients(Guid comboId, int quantity, Dictionary<Guid, int> ingredientUpdates)
        {
            var combo = await _unitOfWorks.ComboRepository.GetByIdAsync(comboId, c => c.DishCombos);
            if (combo == null) throw new Exception("Combo not found");

            foreach (var dishCombo in combo.DishCombos)
            {
                await ReduceDishIngredients(dishCombo.DishId, quantity, ingredientUpdates);
            }
        }

        private async Task UpdateIngredients(Dictionary<Guid, int> ingredientUpdates)
        {
            foreach (var update in ingredientUpdates)
            {
                var ingredientId = update.Key;
                var amountToReduce = update.Value;

                var existingIngredient = await _unitOfWorks.IngredientRepository
                    .FirstOrDefaultAsync(e => e.Id == ingredientId);

                if (existingIngredient == null)
                {
                    throw new Exception($"Ingredient with ID {ingredientId} not found");
                }

                existingIngredient.IngredientAmount -= amountToReduce;
                _unitOfWorks.IngredientRepository.Update(existingIngredient);
            }
        }
    }
}
