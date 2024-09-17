using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Infrastructure.Helpers.GetHelper;
public class PagedResult<T>
{
    /// <summary>
    /// The page number this page represents.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// The size of this page.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// The total number of pages available.
    /// </summary>
    public int TotalNumberOfPages { get; set; }

    /// <summary>
    /// The total number of records available.
    /// </summary>
    public int TotalNumberOfRecords { get; set; }

    /// <summary>
    /// The URL to the next page - if null, there are no more pages.
    /// </summary>
    public List<T> Results { get; set; }
}
