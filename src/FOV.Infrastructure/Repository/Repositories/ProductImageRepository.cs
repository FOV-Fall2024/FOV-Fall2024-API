using FOV.Domain.Entities.ProductAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRepository
{
    public ProductImageRepository(FOVContext context) : base(context)
    {
    }
}
