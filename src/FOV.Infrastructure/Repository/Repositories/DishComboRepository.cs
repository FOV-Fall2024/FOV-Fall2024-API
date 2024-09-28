using FOV.Domain.Entities.ComboAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class DishComboRepository : GenericRepository<DishCombo>, IDishComboRepository
{
    public DishComboRepository(FOVContext context) : base(context)
    {
    }
}
