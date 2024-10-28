using FOV.Domain.Common;
using FOV.Domain.Entities.AttendanceAggregator;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Domain.Entities.WaiterSalaryAggregator;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using Microsoft.AspNetCore.Identity;


namespace FOV.Domain.Entities.UserAggregator;

public class User : IdentityUser , IsSoftDeleted
{
    public Status Status { get; set; }
    public string Address { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string EmployeeCode { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime? HireDate { get; set; } = DateTime.UtcNow;

    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>(); // Use List<Attendance>
    public ICollection<WaiterSchedule> WaiterSchedules { get; set; } = new List<WaiterSchedule>(); // Use List<WaiterSchedule>
    public Restaurant? Restaurant { get; set; }
    public ICollection<WaiterSalary> WaiterSalaries { get; set; } = [];
    public ICollection<IngredientRequest> IngredientRequests { get; set; } = [];
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
}
