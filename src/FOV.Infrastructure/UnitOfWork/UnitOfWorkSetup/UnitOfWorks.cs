using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using FOV.Infrastructure.Repository.Repositories;

namespace FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

public class UnitOfWorks : IUnitOfWorks
{
    private readonly FOVContext _context;
    private readonly IIngredientTypeRepository _ingredientTypeRepository;
    private readonly IIngredientGeneralRepository _ingredientGeneralRepository;
    private readonly IProductGeneralRepository _productGeneralRepository;
    private readonly IProductIngredientGeneralRepository _productIngredientGeneralRepository;

    public UnitOfWorks(FOVContext context, IIngredientTypeRepository ingredientTypeRepository, IIngredientGeneralRepository ingredientGeneralRepository, IProductGeneralRepository productGeneralRepository, IProductIngredientGeneralRepository productIngredientGeneralRepository)
    {
        _context = context;
        _ingredientTypeRepository = ingredientTypeRepository;
        _ingredientGeneralRepository = ingredientGeneralRepository;
        _productGeneralRepository = productGeneralRepository;
        _productIngredientGeneralRepository = productIngredientGeneralRepository;
    }
    public IIngredientTypeRepository IngredientTypeRepository => _ingredientTypeRepository;

    public IIngredientGeneralRepository IngredientGeneralRepository => _ingredientGeneralRepository;

    public IProductGeneralRepository ProductGeneralRepository => _productGeneralRepository;

    public IProductIngredientGeneralRepository ProductIngredientGeneralRepository => _productIngredientGeneralRepository;

    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
