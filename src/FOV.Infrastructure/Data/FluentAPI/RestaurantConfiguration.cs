using FOV.Domain.Entities.RestaurantAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Ingredients).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId);
        builder.HasMany(x => x.Products).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId);
        builder.HasMany(x => x.Combos).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId);
        builder.HasMany(x => x.Tables).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId);
        builder.HasMany(x => x.Employees).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId);
    }
}
