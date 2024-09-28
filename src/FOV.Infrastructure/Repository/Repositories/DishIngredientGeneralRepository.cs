using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;

public class DishIngredientGeneralRepository : GenericRepository<DishIngredientGeneral>, IDishIngredientGeneralRepository
{
    public DishIngredientGeneralRepository(FOVContext context) : base(context)
    {
    }
}
