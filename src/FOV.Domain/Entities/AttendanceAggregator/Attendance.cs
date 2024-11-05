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
    public DateTime? CheckInTime { get; set; } =  DateTime.UtcNow;
    public DateTime? CheckOutTime { get; set; }
    public Guid WaiterScheduleId { get; set; }
    public WaiterSchedule? WaiterSchedule { get; set; }
}
