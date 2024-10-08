﻿using FOV.Domain.Entities.DishAggregator;

namespace FOV.Infrastructure.Repository.IRepositories;
public interface IRefundDishUnitRepository : IGenericRepository<RefundDishUnit>
{
    public int GetTotalConversionFactor(Guid unitId);
}
