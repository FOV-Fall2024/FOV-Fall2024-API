using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class RefundDishInventoryRepository : GenericRepository<RefundDishInventory>, IRefundDishInventoryRepository
{
    public RefundDishInventoryRepository(FOVContext context) : base(context)
    {
    }
}
