using FOV.Domain.Common;
using FOV.Domain.Entities.UserAggregator;

namespace FOV.Domain.Entities.WaiterSalaryAggregator;
public class WaiterSalary : BaseAuditableEntity
{
    public decimal TotalHours { get; set; }
    public decimal TotalSalary { get; set; }
    public string? Status { get; set; }
    public DateTime? PayDate { get; set; } = DateTime.UtcNow;
    public User? User { get; set; }
    public string UserId { get; set; }
    public WaiterSalary()
    {

    }
    public WaiterSalary(string? userId, decimal totalHours, decimal totalSalary, string? status, DateTime payDate)
    {
        this.UserId = userId;
        this.TotalHours = totalHours;
        this.TotalSalary = totalSalary;
        this.Status = status;
        this.PayDate = payDate;
    }
    public void Update(decimal totalHours, decimal totalSalary, string? status, DateTime payDate)
    {
        this.TotalHours = totalHours;
        this.TotalSalary = totalSalary;
        this.Status = status;
        this.PayDate = payDate;
    }
}
