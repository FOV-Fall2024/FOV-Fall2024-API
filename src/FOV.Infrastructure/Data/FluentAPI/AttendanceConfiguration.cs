using FOV.Domain.Entities.AttendanceAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Employee).WithMany(x => x.Attendances).HasForeignKey(x => x.EmployeeId);
    }
}
