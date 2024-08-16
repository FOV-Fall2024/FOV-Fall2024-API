using FOV.Domain.Entities.ComboAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class ComboRepository : GenericRepository<Combo>, IComboRepository
{
    public ComboRepository(FOVContext context) : base(context)
    {
    }
}
