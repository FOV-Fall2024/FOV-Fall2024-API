using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FOV.Domain.Entities.OrderAggregator.Enums;
public enum OrderResponsibilityType
{
    ConfirmOrder = 1,
    Cooked = 2,
    Serve = 3,
    Refund = 4,
    Payment = 5,
    Cancel = 6,
    ConfirmAddMore = 7
}
