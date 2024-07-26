using FOV.Domain.Entities.ProductAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Repository.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{

    private readonly FOVContext _context;

    public CategoryRepository(FOVContext context) : base(context)
    {
        _context = context;
    }

    public async Task UpdateCategoryParent(Guid parentId, int rightValue)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == parentId) ?? throw new Exception();
        _context.Categories.Where(x => x.CategoryMain == category.CategoryMain && x.Right >= rightValue).ExecuteUpdate(x => x.SetProperty(b => b.Right, b => b.Right + 2));
        _context.Categories.Where(x => x.CategoryMain == category.CategoryMain && x.Left > rightValue).ExecuteUpdate(x => x.SetProperty(b => b.Left, b => b.Right + 2));
    }

    public Task DeleteAndUpdateSubCategories(string categoryMain, int leftValue, int rightValue, int width)
    {
        _context.Categories.Where(x => x.CategoryMain == categoryMain && x.Left >= leftValue && x.Right <= rightValue).ExecuteDelete();
        _context.Categories.Where(x => x.CategoryMain == categoryMain && x.Right > rightValue).ExecuteUpdate(x => x.SetProperty(x => x.Right, x => x.Right - width));
        _context.Categories.Where(x => x.CategoryMain == categoryMain && x.Left > rightValue).ExecuteUpdate(x => x.SetProperty(x => x.Left, x => x.Left - width));
        return Task.CompletedTask;
    }
}
