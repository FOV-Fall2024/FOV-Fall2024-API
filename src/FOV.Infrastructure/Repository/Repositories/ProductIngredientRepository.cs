using FOV.Domain.Entities.ProductAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class ProductIngredientRepository : GenericRepository<ProductIngredient>, IProductIngredientRepository
{
    public ProductIngredientRepository(FOVContext context) : base(context)
    {
    }
}
