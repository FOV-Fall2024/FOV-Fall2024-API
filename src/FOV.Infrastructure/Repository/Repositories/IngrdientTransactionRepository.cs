using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class IngrdientTransactionRepository : GenericRepository<IngredientTransaction>, IIngrdientTransactionRepository
{
    public IngrdientTransactionRepository(FOVContext context) : base(context)
    {
    }
}
