using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.DTOs;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Infrastructure.DTOs.ProductQuantity;

namespace FOV.Infrastructure.Repository.IRepositories;
public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
{
    Task<List<OrderDetail>> GetByOrderIdAsync(Guid orderId);
    Task<List<ProductQuantityDtos>> GetTopNDishOfAllOrderDetail(int topN, Guid restaurantId);
    Task<List<ProductQuantityDtos>> GetTopNProductGeneralOfAllOrderDetail(int topN);
    //Task<List<ComboQuantityDtos>> GetTopNComboOfAllOrderDetails(int topN, Guid restaurantId);
}
