using FOV.Domain.Entities.IngredientAggregator;

namespace FOV.Infrastructure.Repository.IRepositories;

public interface IIngredientTypeRepository : IGenericRepository<IngredientType>
{
    Task UpdateParentIngredientType(Guid parentId, int right);
}
