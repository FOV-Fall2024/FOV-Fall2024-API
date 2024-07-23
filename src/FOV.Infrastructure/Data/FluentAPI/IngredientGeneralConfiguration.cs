using FOV.Domain.Entities.IngredientGeneralAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;

public class IngredientGeneralConfiguration : IEntityTypeConfiguration<IngredientGeneral>
{
    public void Configure(EntityTypeBuilder<IngredientGeneral> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.ProductIngredientGenerals).WithOne(x => x.IngredientGeneral).HasForeignKey(x => x.IngredientGeneralId);
    }
}
