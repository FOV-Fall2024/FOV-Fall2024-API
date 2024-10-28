using FOV.Domain.Entities.IngredientAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class IngredientRequestConfiguration : IEntityTypeConfiguration<IngredientRequest>
{
    public void Configure(EntityTypeBuilder<IngredientRequest> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasMany(x => x.IngredientRequestDetails).WithOne(x => x.IngredientRequest).HasForeignKey(x => x.IngredientRequestId);
    }
}
