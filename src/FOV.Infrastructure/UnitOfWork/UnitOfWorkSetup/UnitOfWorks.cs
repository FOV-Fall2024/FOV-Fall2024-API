using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using FOV.Infrastructure.Repository.Repositories;

namespace FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

public class UnitOfWorks : IUnitOfWorks
{
    private readonly FOVContext _context;
    private readonly IIngredientTypeRepository _ingredientTypeRepository;
    private readonly IIngredientGeneralRepository _ingredientGeneralRepository;
    private readonly ITableRepository _tableRepository;
    private readonly IRestaurantRepository _restaurantRepository;

    public UnitOfWorks(FOVContext context, IIngredientTypeRepository ingredientTypeRepository, IIngredientGeneralRepository ingredientGeneralRepository, ITableRepository tableRepository, IRestaurantRepository restaurantRepository)
    {
        _context = context;
        _ingredientTypeRepository = ingredientTypeRepository;
        _ingredientGeneralRepository = ingredientGeneralRepository;
        _tableRepository = tableRepository;
        _restaurantRepository = restaurantRepository;
    }
    public IIngredientTypeRepository IngredientTypeRepository => _ingredientTypeRepository;
    public IIngredientGeneralRepository IngredientGeneralRepository => _ingredientGeneralRepository;
    public ITableRepository TableRepository => _tableRepository;
    public IRestaurantRepository RestaurantRepository => _restaurantRepository;

    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
