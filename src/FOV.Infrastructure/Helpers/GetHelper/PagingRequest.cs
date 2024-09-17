using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;

namespace FOV.Infrastructure.Helpers.GetHelper;
public class PagingRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public SortOrder SortType { get; set; }
    public string ColName { get; set; } = "Id";
}
