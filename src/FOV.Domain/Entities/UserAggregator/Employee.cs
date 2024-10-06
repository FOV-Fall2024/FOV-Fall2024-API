using System;
using System.Collections.Generic;
using FOV.Domain.Common;
using FOV.Domain.Entities.AttendanceAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Domain.Entities.WaiterScheduleAggregator;

namespace FOV.Domain.Entities.UserAggregator;
public class Employee : BaseAuditableEntity, IsSoftDeleted
{
    public DateTime? HireDate { get; set; } = DateTime.UtcNow;
    public string EmployeeCode { get; set; } = string.Empty;
    public User? User { get; set; }
    public string UserId { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public Status Status { get; set; } = Status.Active;
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>(); // Use List<Attendance>
    public ICollection<WaiterSchedule> WaiterSchedules { get; set; } = new List<WaiterSchedule>(); // Use List<WaiterSchedule>
    public Restaurant? Restaurant { get; set; }
    public Guid? RestaurantId { get; set; }

    public Employee() { }

    public Employee(string employeeCode, string userId, Guid restaurantId)
    {
        EmployeeCode = employeeCode;
        HireDate = DateTime.UtcNow;
        UserId = userId;
        RestaurantId = restaurantId;
    }

    public void UpdateState(bool isDelete)
    {
        Status = isDelete ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }
}
