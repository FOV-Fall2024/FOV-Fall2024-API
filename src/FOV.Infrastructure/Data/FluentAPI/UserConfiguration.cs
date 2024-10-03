using FOV.Domain.Entities.UserAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(x => x.Customer).WithOne(x => x.User).HasForeignKey<Customer>(x => x.UserId);
        builder.HasOne(x => x.Employee).WithOne(x => x.User).HasForeignKey<Employee>(x => x.UserId);
        builder.HasMany(x => x.GroupUsers).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        builder.HasMany(x => x.GroupMessages).WithOne(x => x.User).HasForeignKey(x => x.UserId);
    }
}
