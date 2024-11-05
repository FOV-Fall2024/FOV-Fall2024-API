using FOV.Domain.Entities.IngredientSupplyRequestAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class IngredientSupplyRequestDetailRepository : GenericRepository<IngredientSupplyRequestDetail>, IIngredientSupplyRequestDetailRepository
{
    public IngredientSupplyRequestDetailRepository(FOVContext context) : base(context)
    {
    }
}
