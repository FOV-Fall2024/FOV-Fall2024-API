using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

public interface IUnitOfWorks
{
    public IIngredientTypeRepository IngredientTypeRepository { get; }

    public IIngredientGeneralRepository IngredientGeneralRepository { get; }

    public IProductGeneralRepository ProductGeneralRepository { get; }
    public IProductIngredientGeneralRepository ProductIngredientGeneralRepository { get; }
    public Task<int> SaveChangeAsync();
}
