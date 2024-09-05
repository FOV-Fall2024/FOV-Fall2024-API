using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Domain.Entities.OrderAggregator.Enums;
public enum OrderDetailsStatus : byte
{
    Prepare = 1,
    Cook = 2,
    Service = 3,
    Finish = 4,
    Reject = 5,
    Refund = 6
}
