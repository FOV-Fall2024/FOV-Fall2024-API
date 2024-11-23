using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;
using FOV.Domain.Entities.WaiterSalaryAggregator.Enums;
using FOV.Domain.Entities.WaiterScheduleAggregator;

namespace FOV.Domain.Entities.WaiterSalaryAggregator;
public class Salary : BaseAuditableEntity
{
    public SalaryType SalaryType { get; set; }
    public decimal BaseSalary { get; set; }
    public ICollection<WaiterSalary> WaiterSalaries { get; set; } = [];

    public Salary()
    {
    }

    public void UpdateSalary(SalaryType salaryType, decimal baseSalary)
    {
        SalaryType = salaryType;
        BaseSalary = baseSalary;
    }
}
