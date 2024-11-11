using FOV.Domain.Entities.IngredientGeneralAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
internal class IngredientMeasureConfiguration : IEntityTypeConfiguration<IngredientMeasure>
{
    public void Configure(EntityTypeBuilder<IngredientMeasure> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasData(new IngredientMeasure
        {
            Id = Guid.Parse("6531296e-a86a-4fcc-97e7-7e6182a5c011"),
            IngredientMeasureName = "gam",
        }, new IngredientMeasure
        {
            Id = Guid.Parse("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
            IngredientMeasureName = "ml",
        });
    }
}
