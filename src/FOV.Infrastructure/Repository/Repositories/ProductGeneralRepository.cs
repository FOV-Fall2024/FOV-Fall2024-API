using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;

public class ProductGeneralRepository : GenericRepository<ProductGeneral>, IProductGeneralRepository
{
    public ProductGeneralRepository(FOVContext context) : base(context)
    {
    }
}
