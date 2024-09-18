using System.Linq.Expressions;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Repository.Repositories;

public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
{
    private readonly FOVContext _context;
    public RestaurantRepository(FOVContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> AnyAsync(Expression<Func<Restaurant, bool>> predicate)
    {
        return await _context.Restaurants.AnyAsync(predicate);
    }
}
