using FOV.Domain.Entities.ComboAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;

public class ProductComboConfiguration : IEntityTypeConfiguration<ProductCombo>
{
    public void Configure(EntityTypeBuilder<ProductCombo> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
