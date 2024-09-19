using FOV.Domain.Entities.NewProductRecommendAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class NewProductRecommendLogRepository : GenericRepository<NewProductRecommendLog>, INewProductRecommendLogRepository
{
    public NewProductRecommendLogRepository(FOVContext context) : base(context)
    {
    }
}
