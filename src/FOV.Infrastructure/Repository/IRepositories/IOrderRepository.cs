using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.OrderAggregator;

namespace FOV.Infrastructure.Repository.IRepositories;
public interface IOrderRepository : IGenericRepository<Domain.Entities.OrderAggregator.Order>
{
    Task<Domain.Entities.OrderAggregator.Order> GetByTableIdAsync(Guid tableId);
    Task<List<OrderDetail>> GetOrderDishesAndCombo(Guid restaurantId);
}
