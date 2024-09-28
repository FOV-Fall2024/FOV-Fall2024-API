using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class DishRepository : GenericRepository<Dish>, IDishRepository
{
    public DishRepository(FOVContext context) : base(context)
    {
    }
}
