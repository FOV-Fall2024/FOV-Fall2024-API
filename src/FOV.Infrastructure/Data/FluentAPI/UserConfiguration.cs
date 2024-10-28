using FOV.Domain.Entities.UserAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(x => x.Attendances).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        builder.HasMany(x => x.WaiterSchedules).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        builder.HasMany(x => x.WaiterSalaries).WithOne(x => x.User).HasForeignKey(x => x.UserId);
    }
}
