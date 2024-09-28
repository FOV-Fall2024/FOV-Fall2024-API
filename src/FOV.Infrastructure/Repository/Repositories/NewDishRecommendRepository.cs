using FOV.Domain.Entities.NewDishRecommendAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class NewDishRecommendRepository : GenericRepository<NewDishRecommend>, INewDishRecommendRepository
{
    public NewDishRecommendRepository(FOVContext context) : base(context)
    {
    }
}
