using FOV.Domain.Entities.IngredientAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;

public class IngredientGeneralConfiguration : IEntityTypeConfiguration<IngredientGeneral>
{
    public void Configure(EntityTypeBuilder<IngredientGeneral> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
