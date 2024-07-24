using FOV.Domain.Entities.ComboAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FOV.Infrastructure.Data.FluentAPI;

public class ComboConfiguration : IEntityTypeConfiguration<Combo>
{
    public void Configure(EntityTypeBuilder<Combo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.ProductCombos).WithOne(x => x.Combo).HasForeignKey(x => x.ComboId);

    }
}
