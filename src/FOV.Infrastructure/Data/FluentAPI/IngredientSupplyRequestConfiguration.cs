using FOV.Domain.Entities.IngredientSupplyRequestAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class IngredientSupplyRequestConfiguration : IEntityTypeConfiguration<IngredientSupplyRequest>
{
    public void Configure(EntityTypeBuilder<IngredientSupplyRequest> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasMany(x => x.IngredientSupplyRequestDetails).WithOne(x => x.IngredientSupplyRequest).HasForeignKey(x => x.IngredientSupplyRequestId);
    }
}
