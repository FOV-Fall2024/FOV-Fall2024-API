using FOV.Domain.Entities.IngredientAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;

public class IngredientTypeConfiguration : IEntityTypeConfiguration<IngredientType>
{
    public void Configure(EntityTypeBuilder<IngredientType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Ingredients).WithOne(x => x.IngredientType).HasForeignKey(x => x.IngredientTypeId);
        builder.HasMany(x => x.IngredientGenerals).WithOne(x => x.IngredientType).HasForeignKey(x => x.IngredientTypeId);
    }
}
