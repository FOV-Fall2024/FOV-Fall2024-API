using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(FOVContext context) : base(context)
    {
    }
}
