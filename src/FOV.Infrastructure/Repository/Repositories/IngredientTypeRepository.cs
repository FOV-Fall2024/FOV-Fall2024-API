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


}
