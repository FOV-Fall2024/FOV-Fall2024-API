using FOV.Domain.Entities.ProductAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Repository.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{

    private readonly FOVContext _context;

    public CategoryRepository(FOVContext context) : base(context)
    {
        _context = context;
    }

 
}
