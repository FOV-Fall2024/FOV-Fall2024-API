using FOV.Domain.Entities.ProductAggregator;

namespace FOV.Infrastructure.Repository.IRepositories;
public interface ICategoryRepository : IGenericRepository<Category>
{
    Task UpdateCategoryParent(Guid parentId, int rightValue);
    Task DeleteAndUpdateSubCategories(string categoryMain, int leftValue, int rightValue, int width);
}
