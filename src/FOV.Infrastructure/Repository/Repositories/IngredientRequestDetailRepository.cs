using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class IngredientRequestDetailRepository : GenericRepository<IngredientRequestDetail>, IIngredientRequestDetailRepository
{
    public IngredientRequestDetailRepository(FOVContext context) : base(context)
    {
    }
}
