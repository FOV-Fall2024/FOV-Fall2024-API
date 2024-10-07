using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class RefundDishUnitRepository : GenericRepository<RefundDishUnit>, IRefundDishUnitRepository
{
    private readonly FOVContext _context;
    public RefundDishUnitRepository(FOVContext context) : base(context)
    {
        _context = context;
    }

    public int GetTotalConversionFactor(Guid unitId)
    {
        RefundDishUnit unit = _context.RefundDishUnits.FirstOrDefault(u => u.Id == unitId) ?? throw new Exception();
        if (unit == null)
        {
            throw new ArgumentException("Unit not found");
        }

        // Base case: If there is no parent, return the unit's conversion factor
        if (unit.RefundDishUnitParentId == null)
        {
            return unit.ConversionFactor;
        }

        // Recursive case: Multiply the conversion factor by the parent's total conversion factor
        var parentConversionFactor = GetTotalConversionFactor(unit.RefundDishUnitParentId.Value);
        return unit.ConversionFactor * parentConversionFactor;
    }
}
