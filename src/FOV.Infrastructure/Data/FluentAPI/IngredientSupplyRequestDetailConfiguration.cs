using FOV.Domain.Entities.IngredientSupplyRequestAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class IngredientSupplyRequestDetailConfiguration : IEntityTypeConfiguration<IngredientSupplyRequestDetail>
{
    public void Configure(EntityTypeBuilder<IngredientSupplyRequestDetail> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }
}
