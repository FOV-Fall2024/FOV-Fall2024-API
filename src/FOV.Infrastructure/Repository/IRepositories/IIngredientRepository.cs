using FOV.Domain.Entities.IngredientAggregator;

namespace FOV.Infrastructure.Repository.IRepositories;
public interface IIngredientRepository : IGenericRepository<Ingredient>
{
    public decimal GetTotalConversionFactor(Guid unitId);
    Task UpdateRangeAsync(IEnumerable<Ingredient> ingredients);
}
