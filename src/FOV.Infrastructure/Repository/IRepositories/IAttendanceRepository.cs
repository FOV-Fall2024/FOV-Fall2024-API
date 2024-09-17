using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.AttendanceAggregator;

namespace FOV.Infrastructure.Repository.IRepositories;
public interface IAttendanceRepository : IGenericRepository<Attendance>
{
    //Task<Attendance> GetByEmployeeShiftAndDateAsync(Guid employeeId, Guid shiftId, DateTime date);
    Task<Attendance> GetByEmployeeScheduleAndDateAsync(Guid employeeId, Guid waiterScheduleId, DateOnly date);
}
