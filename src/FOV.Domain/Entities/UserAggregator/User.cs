using FOV.Domain.Entities.AttendanceAggregator;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Domain.Entities.WaiterSalaryAggregator;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using Microsoft.AspNetCore.Identity;


namespace FOV.Domain.Entities.UserAggregator;

public class User : IdentityUser<Guid>
{
    public string FullName { get; set; } = string.Empty;
    public DateTime? HireDate { get; set; } = DateTime.UtcNow;
    public string EmployeeCode { get; set; }
    public ICollection<Attendance> Attendances { get; set; } = []; // Use List<Attendance>
    public ICollection<WaiterSchedule> WaiterSchedules { get; set; } = [];
    public virtual ICollection<Order>? Orders { get; set; } = [];
    public Restaurant? Restaurant { get; set; }
    public Guid? RestaurantId { get; set; }
    public Status Status { get; set; }
    public User()
    {

    }
    public User(string employeeCode, string fullName, Guid restaurantId)
    {
        EmployeeCode = employeeCode;
        FullName = fullName;
        RestaurantId = restaurantId;
        HireDate = DateTime.UtcNow;
    }

    public void Update(string phoneNumber, string fullName)
    {
        PhoneNumber = phoneNumber;
        FullName = fullName;
    }
    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        //LastModified = DateTime.UtcNow.AddHours(7);
    }
    public ICollection<WaiterSalary> WaiterSalaries { get; set; } = [];
}
