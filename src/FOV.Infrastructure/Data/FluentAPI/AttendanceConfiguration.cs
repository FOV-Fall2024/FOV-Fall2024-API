using FOV.Domain.Entities.AttendanceAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasOne(a => a.WaiterSchedule)
               .WithMany(ws => ws.Attendances)
               .HasForeignKey(a => a.WaiterScheduleId);
    }
}
