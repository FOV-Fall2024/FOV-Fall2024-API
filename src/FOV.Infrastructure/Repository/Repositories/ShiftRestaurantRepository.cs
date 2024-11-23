using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.ShiftAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class ShiftRestaurantRepository : GenericRepository<ShiftRestaurant>, IShiftRestaurantRepository
{
    public ShiftRestaurantRepository(FOVContext context) : base(context)
    {
    }
}
