using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

public class UnitOfWorks : IUnitOfWorks
{
    private readonly FOVContext _context;
    private readonly IIngredientTypeRepository _ingredientTypeRepository;

    public UnitOfWorks(FOVContext context, IIngredientTypeRepository ingredientTypeRepository)
    {
        _context = context;
        _ingredientTypeRepository = ingredientTypeRepository;

    }
    public IIngredientTypeRepository IngredientTypeRepository => _ingredientTypeRepository;
    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
