using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.ShiftAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class ShiftRepository : GenericRepository<Shift>, IShiftRepository
{
    public ShiftRepository(FOVContext context) : base(context)
    {
    }
}
