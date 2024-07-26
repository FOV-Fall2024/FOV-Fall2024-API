using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

public interface IUnitOfWorks
{
    public IIngredientTypeRepository IngredientTypeRepository { get; }

    public IIngredientGeneralRepository IngredientGeneralRepository { get; }
    public ITableRepository TableRepository { get; }
    public IRestaurantRepository RestaurantRepository { get; }
    public IProductGeneralRepository ProductGeneralRepository { get; }
    public IProductIngredientGeneralRepository ProductIngredientGeneralRepository { get; }

    public ICategoryRepository CategoryRepository { get; }
    public Task<int> SaveChangeAsync();
}
