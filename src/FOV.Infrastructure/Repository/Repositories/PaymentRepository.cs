using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.PaymentAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Repository.Repositories;
public class PaymentRepository : GenericRepository<Payments>, IPaymentRepository
{
    private readonly FOVContext _context;
    public PaymentRepository(FOVContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Payments> GetFirstOrDefaultAsync(Func<Payments, bool> predicate)
    {
        return await _context.Payments.AsQueryable().FirstOrDefaultAsync(p => predicate(p));
    }
}
