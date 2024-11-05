using FOV.Domain.Entities.IngredientSupplyRequestAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class IngredientSupplyRequestRepository : GenericRepository<IngredientSupplyRequest>, IIngredientSupplyRequestRepository
{
    public IngredientSupplyRequestRepository(FOVContext context) : base(context)
    {
    }
}
