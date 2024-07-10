using FOV.Domain.Entities.IngredientAggregator;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Data.Configurations;

public  interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    DbSet<Ingredient> Ingredients { get; }

    DbSet<IngredientType> IngredientTypes { get; }

    DbSet<IngredientGeneral> IngredientGenerals { get;}
}
