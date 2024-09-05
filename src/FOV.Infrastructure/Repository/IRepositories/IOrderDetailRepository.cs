using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator;

namespace FOV.Infrastructure.Repository.IRepositories;
public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
{
    Task<List<OrderDetail>> GetByOrderIdAsync(Guid orderId);
}
