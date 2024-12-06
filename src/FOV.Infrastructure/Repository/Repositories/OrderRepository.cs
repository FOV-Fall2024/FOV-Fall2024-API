using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Repository.Repositories;
public class OrderRepository : GenericRepository<Domain.Entities.OrderAggregator.Order>, IOrderRepository
{
    private readonly FOVContext _context;
    public OrderRepository(FOVContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.OrderAggregator.Order> GetByTableIdAsync(Guid tableId)
    {
        return await _context.Orders
                             .FirstOrDefaultAsync(o => o.TableId == tableId);
    }

    public async Task<List<OrderDetail>> GetOrderDishesAndCombo(Guid restaurantId)
    {
        return await _context.Orders
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Dish)
                    .ThenInclude(dg => dg.DishGeneral)
                        .ThenInclude(c => c.Category)
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Combo)
            .Where(o => o.Table != null && o.Table.RestaurantId == restaurantId && o.OrderStatus == OrderStatus.Cook)
            .SelectMany(o => o.OrderDetails)
            .Where(od => (od.Dish != null || od.Combo != null) && od.Status == OrderDetailsStatus.Cook)
            .ToListAsync();
    }
}
