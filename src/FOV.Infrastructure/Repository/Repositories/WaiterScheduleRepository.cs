using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class WaiterScheduleRepository : GenericRepository<WaiterSchedule>, IWaiterScheduleRepository
{
    public WaiterScheduleRepository(FOVContext context) : base(context)
    {
    }
}
