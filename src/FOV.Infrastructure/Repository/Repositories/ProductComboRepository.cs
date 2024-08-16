using FOV.Domain.Entities.ComboAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class ProductComboRepository : GenericRepository<ProductCombo>, IProductComboRepository
{
    public ProductComboRepository(FOVContext context) : base(context)
    {
    }
}
