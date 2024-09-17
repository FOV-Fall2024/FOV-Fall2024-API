using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class IngredientUnitRepository : GenericRepository<IngredientUnit>, IIngredientUnitRepository
{
    public IngredientUnitRepository(FOVContext context) : base(context)
    {
    }
}
