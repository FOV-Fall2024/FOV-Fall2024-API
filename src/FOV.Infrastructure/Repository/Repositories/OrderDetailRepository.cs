using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.DTOs.ProductQuantity;
using FOV.Infrastructure.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Repository.Repositories;
public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
{
    private readonly FOVContext _context;
    public OrderDetailRepository(FOVContext context) : base(context)
    {
        _context = context;
    }
    public async Task<List<OrderDetail>> GetByOrderIdAsync(Guid orderId)
    {
        return await _context.OrderDetails
            .Where(od => od.OrderId == orderId)
            .ToListAsync();
    }

    public async Task<List<ProductQuantityDtos>> GetTopNProductGeneralOfAllOrderDetail(int topN)
    {
        return await _context.OrderDetails
            .Where(x => x.ProductId != null)
            .Join(_context.Dishes,
                  orderDetail => orderDetail.ProductId,
                  dish => dish.Id,
                  (orderDetail, dish) => new { orderDetail, dish })
            .Join(_context.DishGenerals,
                  dishJoin => dishJoin.dish.DishGeneralId,
                  dishGeneral => dishGeneral.Id,
                  (dishJoin, dishGeneral) => new
                  {
                      dishJoin.orderDetail,
                      dishJoin.dish,
                      dishGeneral.DishName
                  })
            .GroupBy(x => new { x.orderDetail.ProductId, x.DishName })
            .Select(group => new ProductQuantityDtos
            {
                DishId = group.Key.ProductId.Value,
                DishName = group.Key.DishName,
                TotalQuantity = group.Sum(x => x.orderDetail.Quantity)
            })
            .OrderByDescending(x => x.TotalQuantity)
            .Take(topN)
            .ToListAsync();
    }
    public async Task<List<ProductQuantityDtos>> GetTopNDishOfAllOrderDetail(int topN, Guid restaurantId)
    {
        return await _context.OrderDetails
            .Where(x => x.ProductId != null) 
            .Join(_context.Dishes,
                  orderDetail => orderDetail.ProductId,
                  dish => dish.Id,
                  (orderDetail, dish) => new { orderDetail, dish })
            .Join(_context.DishGenerals,
                  dishJoin => dishJoin.dish.DishGeneralId,
                  dishGeneral => dishGeneral.Id,
                  (dishJoin, dishGeneral) => new
                  {
                      dishJoin.orderDetail,
                      dishJoin.dish,
                      dishGeneral.DishName
                  })
            .Where(x => x.dish.RestaurantId == restaurantId)
            .GroupBy(x => new { x.orderDetail.ProductId, x.DishName })
            .Select(group => new ProductQuantityDtos
            {
                DishId = group.Key.ProductId.Value,
                DishName = group.Key.DishName,
                TotalQuantity = group.Sum(x => x.orderDetail.Quantity)
            })
            .OrderByDescending(x => x.TotalQuantity)
            .Take(topN)
            .ToListAsync();
    }
}
