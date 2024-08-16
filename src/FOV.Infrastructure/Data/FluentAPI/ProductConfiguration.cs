using FOV.Domain.Entities.ProductAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FOV.Infrastructure.Data.FluentAPI;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.ProductCombos).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
        builder.HasMany(x => x.OrderDetails).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
    }
}
