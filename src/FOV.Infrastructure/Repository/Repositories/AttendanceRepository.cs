using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.AttendanceAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Repository.Repositories;
public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
{
    private readonly FOVContext _context;
    public AttendanceRepository(FOVContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Attendance?> GetByEmployeeScheduleAndDateAsync(Guid employeeId, Guid waiterScheduleId, DateOnly date)
    {
        //return await _context.Attendances
        //    .Where(a => a.EmployeeId == employeeId
        //             && a.WaiterScheduleId == waiterScheduleId
        //             && a.CheckInTime.Date == date.ToDateTime(TimeOnly.MinValue).Date)
        //    .FirstOrDefaultAsync();

        throw new NotImplementedException();
    }

}
