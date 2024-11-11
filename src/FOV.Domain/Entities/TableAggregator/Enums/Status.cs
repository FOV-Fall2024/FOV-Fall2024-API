using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Domain.Entities.TableAggregator.Enums
{
    public enum Status : byte
    {
        Unknown = 0,
        Active = 1,
        Inactive = 2,
        New = 3,

    }
}
