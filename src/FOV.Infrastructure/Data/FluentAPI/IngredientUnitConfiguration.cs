using FOV.Domain.Entities.IngredientAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class IngredientUnitConfiguration : IEntityTypeConfiguration<IngredientUnit>
{
    public void Configure(EntityTypeBuilder<IngredientUnit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasOne(x => x.Ingredient)
            .WithMany(x => x.IngredientUnits)
            .HasForeignKey(x => x.IngredientId)
            .OnDelete(DeleteBehavior.Cascade); // Adjust as needed

        builder.HasOne(x => x.IngredientUnitParent)
            .WithMany(x => x.ChildUnits)
            .HasForeignKey(x => x.IngredientUnitParentId)
            .OnDelete(DeleteBehavior.Restrict); // Prevents circular cascade delete issues
    }
}
