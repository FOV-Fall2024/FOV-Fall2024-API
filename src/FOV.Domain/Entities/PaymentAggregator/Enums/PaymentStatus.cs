using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Domain.Entities.PaymentAggregator.Enums;
public enum PaymentStatus : byte
{
    Pending = 0,
    Paid = 1,
    Failed = 2,
    Refunded = 3
}
