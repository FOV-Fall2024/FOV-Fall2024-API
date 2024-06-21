using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Domain.Common
{
    public abstract class IsSoftDeleted
    {
        public bool IsDeleted { get; set; }
    }
}
