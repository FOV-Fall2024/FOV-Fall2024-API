using FOV.Domain.Entities.DishAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;

class RefundDishInventoryConfiguration : IEntityTypeConfiguration<RefundDishInventory>
{
    public void Configure(EntityTypeBuilder<RefundDishInventory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasOne(x => x.Dish).WithOne(x => x.RefundDishInventory).HasForeignKey<RefundDishInventory>(x => x.DishId);
        builder.HasMany(x => x.Transaction).WithOne(x => x.RefundDishInventory).HasForeignKey(x => x.RefundDishInventoryId);
    }
}
