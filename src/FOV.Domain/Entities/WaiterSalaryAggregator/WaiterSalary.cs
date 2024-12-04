using FOV.Domain.Common;
using FOV.Domain.Entities.UserAggregator;

namespace FOV.Domain.Entities.WaiterSalaryAggregator;
public class WaiterSalary : BaseAuditableEntity
{
    public DateTime? PayDate { get; set; } = DateTime.UtcNow;
    public Salary? Salary { get; set; }
    public Guid? SalaryId { get; set; }
    public User? User { get; set; }
    public Guid? UserId { get; set; }
    public decimal TotalShifts { get; set; }
    public decimal TotalHoursWorked { get; set; }
    public decimal ActualHoursWorked { get; set; }
    public decimal RegularSalary { get; set; }
    public decimal OvertimeSalary { get; set; }
    public decimal Penalty { get; set; }
    public decimal TotalSalaries { get; set; }
    public string? Status { get; set; }
    public WaiterSalary()
    {

    }
    public WaiterSalary(Guid? userId, decimal totalShifts, decimal totalSalaries, string? status, DateTime payDate)
    {
        this.UserId = userId;
        this.TotalShifts = totalShifts;
        this.TotalSalaries = totalSalaries;
        this.Status = status;
        this.PayDate = payDate;
    }
    public void Update(decimal totalShifts, decimal totalSalaries, string? status, DateTime payDate)
    {
        this.TotalShifts = totalShifts;
        this.TotalSalaries = totalSalaries;
        this.Status = status;
        this.PayDate = payDate;
    }
}
