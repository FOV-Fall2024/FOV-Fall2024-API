using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Domain.Entities.WaiterScheduleAggregator;

namespace FOV.Domain.Entities.ShiftAggregator;
public class Shift : BaseAuditableEntity, IsSoftDeleted
{
    public string? ShiftName { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public ICollection<WaiterSchedule> WaiterSchedules { get; set; } = [];
    public ICollection<ShiftRestaurant> ShiftRestaurants { get; set; } = [];
    public Status Status { get; set; }


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
    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }
}
