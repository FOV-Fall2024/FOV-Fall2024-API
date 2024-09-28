using FOV.Domain.Entities.NewDishRecommendAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class NewDishRecommendLogRepository : GenericRepository<NewDishRecommendLog>, INewDishRecommendLogRepository
{
    public NewDishRecommendLogRepository(FOVContext context) : base(context)
    {
    }
}
