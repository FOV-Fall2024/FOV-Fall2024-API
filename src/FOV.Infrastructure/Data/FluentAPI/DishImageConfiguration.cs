using FOV.Domain.Entities.DishAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class DishImageConfiguration : IEntityTypeConfiguration<DishImage>
{
    public void Configure(EntityTypeBuilder<DishImage> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }
}
