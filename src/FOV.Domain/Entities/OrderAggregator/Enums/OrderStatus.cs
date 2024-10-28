using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Domain.Entities.OrderAggregator.Enums;
public enum OrderStatus : byte
{
    Prepare = 1,
    Cook = 2,
    Service = 3,
    Payment = 4,
    Finish = 5,
    Canceled = 6
}
