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
        new Category("Noodle")
        {
            Id = Guid.NewGuid(),  // Assign a unique ID
            CategoryMain = "Noodle",
            Left = 1,
            Right = 2,
            IsDeleted = false
        },
        new Category("Salad")
        {
            Id = Guid.NewGuid(),  // Assign a unique ID
            CategoryMain = "Salad",
            Left = 1,
            Right = 2,
            IsDeleted = false
        }
    );

    }
}
