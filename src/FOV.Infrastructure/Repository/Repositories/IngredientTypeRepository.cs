using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Repository.Repositories;

public class IngredientTypeRepository : GenericRepository<IngredientType>, IIngredientTypeRepository
{
    private readonly FOVContext _context;
    public IngredientTypeRepository(FOVContext context) : base(context)
    {
        _context = context;
    }

    public async Task UpdateParentIngredientType(Guid parentId, int right)
    {
        var category = await _context.IngredientTypes.FirstOrDefaultAsync(x => x.Id == parentId);
        _context.IngredientTypes.Where(x => x.IngredientMain == category.IngredientMain && x.Right >= right).ExecuteUpdate(x => x.SetProperty(b => b.Right, b => b.Right + 2));
        _context.IngredientTypes.Where(x => x.IngredientMain == category.IngredientMain && x.Left > right).ExecuteUpdate(x => x.SetProperty(b => b.Left, b => b.Right + 2));
    }
}
