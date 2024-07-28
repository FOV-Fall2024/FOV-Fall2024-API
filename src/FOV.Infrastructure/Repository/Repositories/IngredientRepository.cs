using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
{
    public IngredientRepository(FOVContext context) : base(context)
    {
    }
}
