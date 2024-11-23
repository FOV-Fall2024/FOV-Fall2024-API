using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.WaiterSalaryAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class SalaryRepository : GenericRepository<Salary>, ISalaryRepository
{
    public SalaryRepository(FOVContext context) : base(context)
    {
    }
}
