using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;
using FOV.Domain.Entities.AttendanceAggregator;
using FOV.Domain.Entities.ShiftAggregator;
using FOV.Domain.Entities.UserAggregator;

namespace FOV.Domain.Entities.WaiterScheduleAggregator;
public class WaiterSchedule : BaseAuditableEntity
{
    public DateOnly DateTime { get; set; }
    public Guid? EmployeeId { get; set; }
    public Guid ShiftId { get; set; }
    public Shift? Shift { get; set; }
    public Employee? Employee { get; set; }
    public ICollection<Attendance> Attendances { get; set; } = [];
    public WaiterSchedule()
    {

    }
    public WaiterSchedule(DateOnly dateTime, Guid shiftId, Guid? employeeId)
    {
        this.DateTime = dateTime;
        this.ShiftId = shiftId;
        this.EmployeeId = employeeId;
    }
    public void Update(DateOnly dateTime, Guid shiftId, Guid? employeeId)
    {
        this.DateTime = dateTime;
        this.ShiftId = shiftId;
        this.EmployeeId = employeeId;
    }
}
