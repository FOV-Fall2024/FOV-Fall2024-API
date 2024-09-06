using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Infrastructure.Configuration;
public class ElasticSettings
{
    public string Url { get; set; }
    public string DefaultIndex { get; set; }
    public string UserName { get; set; }

    public string Password { get; set; }
}
