using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Domain.Entities.TableAggregator.Enums;
public enum TableStatus : byte
{
    Unknown = 0,
    Available = 1,
    NotAvailable = 2
}
