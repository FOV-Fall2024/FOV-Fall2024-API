using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Infrastructure.Constant;

public static class CurrentTime
{
    public static readonly DateTimeOffset RecentTime = DateTime.UtcNow.AddHours(7);
}
