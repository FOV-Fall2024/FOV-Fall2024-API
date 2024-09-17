using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.WaiterScheduleAggregator;

namespace FOV.Domain.Entities.AttendanceAggregator;
public class Attendance : BaseAuditableEntity
{
    public DateTimeOffset CheckInTime { get; set; }
    public DateTimeOffset? CheckOutTime { get; set; }
    public Guid EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    public Guid WaiterScheduleId { get; set; }
    public WaiterSchedule? WaiterSchedule { get; set; }
}
