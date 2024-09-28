using FOV.Domain.Entities.ComboAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;

public class DishComboConfiguration : IEntityTypeConfiguration<DishCombo>
{
    public void Configure(EntityTypeBuilder<DishCombo> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
