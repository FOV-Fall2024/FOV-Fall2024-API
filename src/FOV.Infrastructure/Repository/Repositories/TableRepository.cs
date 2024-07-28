using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.TableAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;

public class TableRepository : GenericRepository<Table>, ITableRepository
{
    public TableRepository(FOVContext context) : base(context)
    {
    }
}
