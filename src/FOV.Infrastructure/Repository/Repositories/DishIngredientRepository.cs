using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class DishIngredientRepository : GenericRepository<DishIngredient>, IDishIngredientRepository
{
    public DishIngredientRepository(FOVContext context) : base(context)
    {
    }
}
