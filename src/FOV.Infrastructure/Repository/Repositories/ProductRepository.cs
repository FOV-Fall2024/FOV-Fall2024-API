using FOV.Domain.Entities.ProductAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(FOVContext context) : base(context)
    {
    }
}
