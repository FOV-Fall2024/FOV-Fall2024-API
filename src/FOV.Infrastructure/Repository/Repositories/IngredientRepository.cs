using System.Linq.Dynamic.Core;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Repository.Repositories;
public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
{
    private readonly FOVContext _context;
    public IngredientRepository(FOVContext context) : base(context)
    {
        _context = context;
    }

    public decimal GetTotalConversionFactor(Guid unitId)
    {
        IngredientUnit unit = _context.IngredientUnits.FirstOrDefault(u => u.Id == unitId) ?? throw new Exception();
        if (unit == null)
        {
            throw new ArgumentException("Unit not found");
        }

        // Base case: If there is no parent, return the unit's conversion factor
        if (unit.IngredientUnitParentId == null)
        {
            return unit.ConversionFactor;
        }

        // Recursive case: Multiply the conversion factor by the parent's total conversion factor
        var parentConversionFactor = GetTotalConversionFactor(unit.IngredientUnitParentId.Value);
        return unit.ConversionFactor * parentConversionFactor;
    }

    public async Task HandleExpried()
    {
        var ingredienttypes = _context.IngredientTypes.ToList();
        foreach (var ingredientType in ingredienttypes)
        {
            foreach (var ingredient in ingredientType.Ingredients)
            {
                foreach (var transaction in ingredient.IngredientTransactions.Where(x => x.IsDeleted == false))
                {
                    if (transaction.TransactionDate.AddDays(ingredientType.ExpiredTime) >= DateTime.UtcNow)
                    {
                        //? Add Transacation that remove out of 
                        Ingredient updateIngredient = await _context.Ingredients.SingleOrDefaultAsync(x => x.Id == ingredient.Id) ?? throw new Exception();
                        //? Add Transfer to exprireQuantity
                        updateIngredient.UpdateExpriedQuantity(transaction.Quantity);
                        _context.Ingredients.Update(updateIngredient);

                    }
                }

            }
        }
    }
}
