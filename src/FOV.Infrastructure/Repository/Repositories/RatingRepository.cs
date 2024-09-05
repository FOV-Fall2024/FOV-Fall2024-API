using FOV.Domain.Entities.OrderAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class RatingRepository : GenericRepository<Rating>, IRatingRepository
{
    public RatingRepository(FOVContext context) : base(context)
    {
    }
}
