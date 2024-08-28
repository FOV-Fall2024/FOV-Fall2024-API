using FOV.Domain.Entities.AttendanceAggregator;
using FOV.Domain.Entities.GroupChatAggregator;
using FOV.Domain.Entities.WaiterSalaryAggregator;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using Microsoft.AspNetCore.Identity;


namespace FOV.Domain.Entities.UserAggregator;

public class User : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;

    public Customer? Customer { get; set; }
    public Employee? Employee { get; set; }

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
    public virtual ICollection<GroupUser> GroupUsers { get; set; } = [];
    public ICollection<WaiterSalary> WaiterSalaries { get; set; } = [];
    public ICollection<Attendance> Attendances { get; set; } = [];
    public ICollection<WaiterSchedule> WaiterSchedules { get; set; } = [];
    public virtual ICollection<GroupMessage> GroupMessages { get; set; } = [];
}
