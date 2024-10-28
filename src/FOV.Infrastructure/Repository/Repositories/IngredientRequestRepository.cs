using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class IngredientRequestRepository : GenericRepository<IngredientRequest>, IIngredientRequestRepository
{
    public IngredientRequestRepository(FOVContext context) : base(context)
    {
    }
}
