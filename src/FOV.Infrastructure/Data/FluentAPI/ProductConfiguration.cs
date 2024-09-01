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
        builder.HasMany(x => x.ProductImages).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
        builder.HasData(new Product
        {
            Id = Guid.Parse("9ffc9ec6-6b72-4467-aaeb-1e45dc0540c3"),
            CategoryId = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c011"),
            ProductName = "7up",
            ProductDescription = "Description",
            ProductGeneralId = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c013"),
            RestaurantId = Guid.Parse("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0")
        });
    }
}
