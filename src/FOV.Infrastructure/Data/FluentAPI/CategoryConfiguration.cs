using FOV.Domain.Entities.ProductAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.ProductGenerals).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        builder.HasData(
        new Category("Packaged")
        {
            Id = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c011"),  //? 
            CategoryMain = "Packaged",
            Left = 1,
            Right = 2,
            IsDeleted = false
        },
        new Category("Processed")
        {
            Id = Guid.Parse("3140b8af-2124-44fa-8f43-907cddc26c3d"),  // Assign a unique ID
            CategoryMain = "Processed",
            Left = 1,
            Right = 2,
            IsDeleted = false
        }
    );

    }
}
