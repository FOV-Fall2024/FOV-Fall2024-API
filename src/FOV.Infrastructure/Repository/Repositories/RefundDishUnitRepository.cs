using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class RefundDishUnitRepository : GenericRepository<RefundDishUnit>, IRefundDishUnitRepository
{
    public RefundDishUnitRepository(FOVContext context) : base(context)
    {
    }
}
