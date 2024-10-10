using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class DishGeneralImageRepository : GenericRepository<DishGeneralImage>, IDishGeneralImageRepository
{
    public DishGeneralImageRepository(FOVContext context) : base(context)
    {
    }
}
