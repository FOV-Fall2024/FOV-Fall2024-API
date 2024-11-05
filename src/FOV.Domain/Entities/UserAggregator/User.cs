using FOV.Domain.Entities.AttendanceAggregator;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.WaiterSalaryAggregator;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using Microsoft.AspNetCore.Identity;


namespace FOV.Domain.Entities.UserAggregator;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public int Point { get; set; } = 0;
    public string LastName { get; set; } = string.Empty;
    public DateTime? HireDate { get; set; } = DateTime.UtcNow;
    public string EmployeeCode { get; set; } = string.Empty;
    public ICollection<Attendance> Attendances { get; set; } = []; // Use List<Attendance>
    public ICollection<WaiterSchedule> WaiterSchedules { get; set; } = [];
    public ICollection<Order> Orders { get; set; } = [];
    public Restaurant? Restaurant { get; set; }
    public Guid? RestaurantId { get; set; }
    public User()
    {

    }

    public User(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = firstName + " " + lastName;
    }

    public void Update(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public ICollection<WaiterSalary> WaiterSalaries { get; set; } = [];
   // public ICollection<Attendance> Attendances { get; set; } = [];

}
