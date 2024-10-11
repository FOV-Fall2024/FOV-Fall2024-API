using FOV.Domain.Common;
using FOV.Domain.Entities.ComboAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FOV.Infrastructure.Data.FluentAPI;

public class ComboConfiguration : IEntityTypeConfiguration<Combo>
{
    public void Configure(EntityTypeBuilder<Combo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasMany(x => x.DishCombos).WithOne(x => x.Combo).HasForeignKey(x => x.ComboId);
        builder.HasMany(x => x.OrderDetails).WithOne(x => x.Combo).HasForeignKey(x => x.ComboId);
        builder.HasData(
            new Combo
            {
                Id = Guid.Parse("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                ComboName = "Combo 1",
                ComboStatus = Domain.Entities.ComboAggregator.Enums.ComboStatus.InStock,
                Price = 50.00m,
                PercentReduce = 10.0m,
                RestaurantId = Guid.Parse("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                Status = Domain.Entities.TableAggregator.Enums.Status.Active,
                Thumbnail = "img1",
                Created = DefaultDatetime.MinValue,
                LastModified = DefaultDatetime.MinValue,
                

            },
            new Combo
            {
                Id = Guid.Parse("3907a193-c2ae-4f40-936b-9a2438595123"),
                ComboName = "Combo 2",
                ComboStatus = Domain.Entities.ComboAggregator.Enums.ComboStatus.InStock,
                Price = 30.00m,
                PercentReduce = 5.0m,
                RestaurantId = Guid.Parse("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                Status = Domain.Entities.TableAggregator.Enums.Status.Active,
                Thumbnail = "img2",
                Created = DefaultDatetime.MinValue,
                LastModified = DefaultDatetime.MinValue,
            },
            new Combo
            {
                Id = Guid.Parse("921b269a-db6e-4a1d-b285-70df523e010e"),
                ComboName = "Combo 3",
                ComboStatus = Domain.Entities.ComboAggregator.Enums.ComboStatus.InStock,
                Price = 30.00m,
                PercentReduce = 5.0m,
                RestaurantId = Guid.Parse("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                Status = Domain.Entities.TableAggregator.Enums.Status.Active,
                Thumbnail = "img3",
                Created = DefaultDatetime.MinValue,
                LastModified = DefaultDatetime.MinValue,

            }
        );
    }
}
