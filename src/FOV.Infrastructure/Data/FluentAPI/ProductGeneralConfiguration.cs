using FOV.Domain.Entities.ProductGeneralAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FOV.Infrastructure.Data.FluentAPI;

public class ProductGeneralConfiguration : IEntityTypeConfiguration<ProductGeneral>
{
    public void Configure(EntityTypeBuilder<ProductGeneral> builder)
    {
        builder.HasMany(x => x.Ingredients).WithOne(x => x.ProductGeneral).HasForeignKey(x => x.ProductGeneralId);
        builder.HasKey(x => x.Id);
    }
}
