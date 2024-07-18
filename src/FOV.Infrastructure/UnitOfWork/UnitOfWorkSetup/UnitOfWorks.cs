using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using FOV.Infrastructure.Repository.Repositories;

namespace FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

public class UnitOfWorks : IUnitOfWorks
{
    private readonly FOVContext _context;
    private readonly IIngredientTypeRepository _ingredientTypeRepository;
    private readonly IIngredientGeneralRepository _ingredientGeneralRepository;

    public UnitOfWorks(FOVContext context, IIngredientTypeRepository ingredientTypeRepository, IIngredientGeneralRepository ingredientGeneralRepository)
    {
        _context = context;
        _ingredientTypeRepository = ingredientTypeRepository;
        _ingredientGeneralRepository = ingredientGeneralRepository;
    }
    public IIngredientTypeRepository IngredientTypeRepository => _ingredientTypeRepository;

    public IIngredientGeneralRepository IngredientGeneralRepository => _ingredientGeneralRepository;

    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
