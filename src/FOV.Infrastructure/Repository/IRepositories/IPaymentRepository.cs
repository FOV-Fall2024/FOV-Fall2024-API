using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.PaymentAggregator;
using static Elastic.Clients.Elasticsearch.JoinField;

namespace FOV.Infrastructure.Repository.IRepositories;
public interface IPaymentRepository : IGenericRepository<Payments>
{
    Task<Payments> GetFirstOrDefaultAsync(Func<Payments, bool> predicate);
}
