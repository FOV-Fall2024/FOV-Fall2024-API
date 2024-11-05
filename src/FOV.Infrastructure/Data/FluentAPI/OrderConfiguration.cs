using FOV.Domain.Entities.OrderAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI
{
    public class OrderConfiguration : IEntityTypeConfiguration<Domain.Entities.OrderAggregator.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.OrderAggregator.Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
          //  builder.HasMany(x => x.IngredientTransactions).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
        }
    }

}
