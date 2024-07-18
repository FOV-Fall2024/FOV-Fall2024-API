using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;


namespace FOV.Infrastructure.Repository.Repositories;

public class IngredientGeneralRepository : GenericRepository<IngredientGeneral>, IIngredientGeneralRepository
{
    public IngredientGeneralRepository(FOVContext context) : base(context)
    {
    }
}
