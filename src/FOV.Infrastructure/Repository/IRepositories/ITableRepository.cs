﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.TableAggregator;

namespace FOV.Infrastructure.Repository.IRepositories;

public interface ITableRepository : IGenericRepository<Table>
{
    public Task<int?> GetHighestTableNumberAsync(Guid restaurantId);
}
