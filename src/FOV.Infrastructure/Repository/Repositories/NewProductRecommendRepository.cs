using FOV.Domain.Entities.NewProductRecommendAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class NewProductRecommendRepository : GenericRepository<NewProductRecommend>, INewProductRecommendRepository
{
    public NewProductRecommendRepository(FOVContext context) : base(context)
    {
    }
}
