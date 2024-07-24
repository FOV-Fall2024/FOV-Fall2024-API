using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;

public class ProductIngredientGeneralRepository : GenericRepository<ProductIngredientGeneral>, IProductIngredientGeneralRepository
{
    public ProductIngredientGeneralRepository(FOVContext context) : base(context)
    {
    }
}
