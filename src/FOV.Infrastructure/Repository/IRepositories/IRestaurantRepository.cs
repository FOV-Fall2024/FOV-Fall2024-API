    using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.RestaurantAggregator;

namespace FOV.Infrastructure.Repository.IRepositories;

public interface IRestaurantRepository : IGenericRepository<Restaurant>
{
    Task<bool> AnyAsync(Expression<Func<Restaurant, bool>> predicate);
}
