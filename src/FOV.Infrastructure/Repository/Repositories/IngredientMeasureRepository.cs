using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class IngredientMeasureRepository : GenericRepository<IngredientMeasure>, IIngredientMeasureRepository
{
    public IngredientMeasureRepository(FOVContext context) : base(context)
    {
    }
}
