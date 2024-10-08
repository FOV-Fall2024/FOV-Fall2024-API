using FOV.Domain.Entities.WaiterScheduleAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class WaiterScheduleConfiguration : IEntityTypeConfiguration<WaiterSchedule>
{
    public void Configure(EntityTypeBuilder<WaiterSchedule> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasMany(x => x.Attendances).WithOne(x => x.WaiterSchedule).HasForeignKey(x => x.WaiterScheduleId);
    }
}
