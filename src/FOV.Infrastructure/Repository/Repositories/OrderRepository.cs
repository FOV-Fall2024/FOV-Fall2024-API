using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Repository.Repositories;
public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly FOVContext _context;
    public OrderRepository(FOVContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Order> GetByTableIdAsync(Guid tableId)
    {
        return await _context.Orders
                             .FirstOrDefaultAsync(o => o.TableId == tableId);
    }
}

