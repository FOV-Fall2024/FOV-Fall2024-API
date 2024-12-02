using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class OrderResponsibilityRepository : GenericRepository<OrderResponsibility>, IOrderResponsibilityRepository
{
    public OrderResponsibilityRepository(FOVContext context) : base(context)
    {
    }
}
