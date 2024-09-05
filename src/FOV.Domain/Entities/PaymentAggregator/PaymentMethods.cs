using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;

namespace FOV.Domain.Entities.PaymentAggregator;
public class PaymentMethods : BaseAuditableEntity
{
    public string? PaymentMethodName { get; set; }
    public ICollection<Payments> Payments { get; set; } = [];
}
