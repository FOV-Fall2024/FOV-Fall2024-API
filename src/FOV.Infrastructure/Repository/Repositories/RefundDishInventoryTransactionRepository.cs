using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class RefundDishInventoryTransactionRepository : GenericRepository<RefundDishInventoryTransaction>, IRefundDishInventoryTransactionRepository
{
    public RefundDishInventoryTransactionRepository(FOVContext context) : base(context)
    {
    }
}
