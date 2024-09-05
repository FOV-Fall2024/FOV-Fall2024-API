using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.PaymentAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
public class PaymentRepository : GenericRepository<Payments>, IPaymentRepository
{
    public PaymentRepository(FOVContext context) : base(context)
    {
    }
}
