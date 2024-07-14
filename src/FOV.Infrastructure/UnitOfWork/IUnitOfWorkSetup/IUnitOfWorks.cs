using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

public interface IUnitOfWorks
{
    public IIngredientTypeRepository IngredientTypeRepository { get; }
    public Task<int> SaveChangeAsync();
}
