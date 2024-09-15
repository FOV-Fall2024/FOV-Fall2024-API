using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;
using FOV.Domain.Entities.WaiterScheduleAggregator;

namespace FOV.Domain.Entities.ShiftAggregator;
public class Shift : BaseAuditableEntity, IsSoftDeleted
{
    public string? ShiftName { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public ICollection<WaiterSchedule> WaiterSchedules { get; set; } = [];
    public bool IsDeleted { get; set; }

    public Shift()
    {

    }
    public Shift(string? shiftName, TimeSpan? startTime, TimeSpan? endTime)
    {
        this.ShiftName = shiftName;
        this.StartTime = startTime;
        this.EndTime = endTime;
    }
    public void Update(string? shiftName, TimeSpan? startTime, TimeSpan? endTime)
    {
        this.ShiftName = shiftName;
        this.StartTime = startTime;
        this.EndTime = endTime;
    }
    public void UpdateState(bool state) => IsDeleted = state;
}
