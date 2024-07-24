using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;

public class IngredientTypeRepository : GenericRepository<IngredientType>, IIngredientTypeRepository
{
    public IngredientTypeRepository(FOVContext context) : base(context)
    {
    }
}
