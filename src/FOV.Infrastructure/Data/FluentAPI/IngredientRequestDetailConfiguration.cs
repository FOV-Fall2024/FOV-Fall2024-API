using FOV.Domain.Entities.IngredientAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class IngredientRequestDetailConfiguration : IEntityTypeConfiguration<IngredientRequestDetail>
{
    public void Configure(EntityTypeBuilder<IngredientRequestDetail> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

    }
}
