using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.TableAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Repository.Repositories;

public class TableRepository : GenericRepository<Table>, ITableRepository
{
    private readonly FOVContext _context;
    public TableRepository(FOVContext context) : base(context)
    {
        _context = context;
    }
    public async Task<int?> GetHighestTableNumberAsync(Guid restaurantId)
    {
        return await _context.Tables
         .Where(t => t.RestaurantId == restaurantId)
         .Select(t => (int?)t.TableNumber) // Explicitly cast to nullable int
         .MaxAsync() ?? 0;
    }
}
