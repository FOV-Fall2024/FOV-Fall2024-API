using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class DishImageRepository : GenericRepository<DishImage>, IDishImageRepository
{
    public DishImageRepository(FOVContext context) : base(context)
    {
    }
}
