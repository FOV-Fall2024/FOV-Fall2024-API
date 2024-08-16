using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class WaiterScheduleConfiguration : IEntityTypeConfiguration<WaiterSchedule>
{
    public void Configure(EntityTypeBuilder<WaiterSchedule> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Attendances).WithOne(x => x.WaiterSchedule).HasForeignKey(x => x.WaiterScheduleId);
        builder.HasOne(x => x.User).WithMany(x => x.WaiterSchedules).HasForeignKey(x => x.UserId);
    }
}
