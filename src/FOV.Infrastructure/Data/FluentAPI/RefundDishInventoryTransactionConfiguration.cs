using FOV.Domain.Entities.DishAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class RefundDishInventoryTransactionConfiguration : IEntityTypeConfiguration<RefundDishInventoryTransaction>
{
    public void Configure(EntityTypeBuilder<RefundDishInventoryTransaction> builder)
    {
       builder.HasKey(x => x.Id);
    }
}
