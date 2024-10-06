using FOV.Domain.Entities.DishAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class RefundDishUnitConfiguration : IEntityTypeConfiguration<RefundDishUnit>
{
    public void Configure(EntityTypeBuilder<RefundDishUnit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasOne(x => x.RefundDishInventory).WithMany(x => x.DishUnits).HasForeignKey(x => x.RefundDishInventoryId).OnDelete(DeleteBehavior.Cascade); 
        builder.HasOne(x => x.RefundDishUnitParent).WithMany(x => x.RefundDishChildUnits).HasForeignKey(x => x.RefundDishUnitParentId).OnDelete(DeleteBehavior.Restrict);
    }
}
