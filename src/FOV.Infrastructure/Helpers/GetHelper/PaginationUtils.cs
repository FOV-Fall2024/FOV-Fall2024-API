using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;

namespace FOV.Infrastructure.Helpers.GetHelper;
public static class PaginationUtils
{
    public static (int page, int pageSize, SortOrder sortType, string sortField) GetPaginationAndSortingValues(PagingRequest? request)
    {
        var page = request?.Page ?? 1;
        var pageSize = request?.PageSize ?? 10;
        var sortType = request?.SortType ?? SortOrder.Ascending;
        var sortField = request?.ColName ?? "Id";

        return (page, pageSize, sortType, sortField);
    }
}
