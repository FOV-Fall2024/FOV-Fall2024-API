using FOV.Domain.Entities.AttendanceAggregator;
using FOV.Domain.Entities.WaiterSalaryAggregator;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using Microsoft.AspNetCore.Identity;


namespace FOV.Domain.Entities.UserAggregator;

public class User : IdentityUser
{

    public ICollection<WaiterSalary> WaiterSalaries { get; set; } = [];
    public ICollection<Attendance> Attendances { get; set; } = [];
    public ICollection<WaiterSchedule> WaiterSchedules { get; set; } = [];
}
