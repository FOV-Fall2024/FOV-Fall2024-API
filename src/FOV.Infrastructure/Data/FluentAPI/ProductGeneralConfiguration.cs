using FOV.Domain.Entities.ProductGeneralAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FOV.Infrastructure.Data.FluentAPI;

public class ProductGeneralConfiguration : IEntityTypeConfiguration<ProductGeneral>
{
    public void Configure(EntityTypeBuilder<ProductGeneral> builder)
    {
        builder.HasMany(x => x.Products).WithOne(x => x.ProductGeneral).HasForeignKey(x => x.ProductGeneralId);
        builder.HasMany(x => x.Ingredients).WithOne(x => x.ProductGeneral).HasForeignKey(x => x.ProductGeneralId);
        builder.HasKey(x => x.Id);
        builder.HasData(
            new ProductGeneral()
            {
                Id = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c012"),
                CategoryId = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c011"),
                ProductName = "Coca-Cola",
                ProductDescription = "Coca-Cola ngon ",
                IsDeleted = false,
            },
             new ProductGeneral()
             {
                 Id = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c013"),
                 CategoryId = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c011"),
                 ProductName = "7up",
                 ProductDescription = "7up ngon ",
                 IsDeleted = false,
             },
             new ProductGeneral()
             {
                 Id = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c022"),
                 CategoryId = Guid.Parse("3140b8af-2124-44fa-8f43-907cddc26c3d"),
                 ProductName = " Caprese Salad",
                 ProductDescription = " Caprese Salad ngon ",
                 IsDeleted = false,
             }
    );
    }
}
