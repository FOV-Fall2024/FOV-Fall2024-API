using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;
using FOV.Domain.Entities.WaiterSalaryAggregator.Enums;

namespace FOV.Domain.Entities.WaiterSalaryAggregator;
public class Salary : BaseAuditableEntity
{
    public SalaryType SalaryType { get; set; }
    public decimal BaseSalary { get; set; }
}
