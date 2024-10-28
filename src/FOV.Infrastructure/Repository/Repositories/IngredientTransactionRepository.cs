using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class IngredientTransactionRepository : GenericRepository<IngredientTransaction>, IIngrdientTransactionRepository
{
    public IngredientTransactionRepository(FOVContext context) : base(context)
    {
    }
}
