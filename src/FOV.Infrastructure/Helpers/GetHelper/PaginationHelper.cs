using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;

namespace FOV.Infrastructure.Helpers.GetHelper;
public class PaginationHelper<T> where T : class
{
    public static PagedResult<T> EmptyResult(int pageSize)
    {
        return new PagedResult<T>
        {
            Results = new List<T>(),
            PageNumber = 1,
            PageSize = pageSize,
            TotalNumberOfPages = 0,
            TotalNumberOfRecords = 0
        };
    }

    public static PagedResult<T> Paging(List<T> list, int? page, int? pageSize)
    {
        try
        {
            if (page == null && pageSize == null)
            {
                pageSize = list.Count;
                page = 1;
            }
            else
            if (page < 1 || pageSize < 1)
            {
                return null;
            }
            var skipAmount = pageSize * (page - 1);
            var totalNumberOfRecords = list.Count;
            var results = list.Skip((int)skipAmount).Take((int)pageSize).ToList();
            var mod = totalNumberOfRecords % pageSize;
            var totalPageCount = totalNumberOfRecords / pageSize + (mod == 0 ? 0 : 1);
            return new PagedResult<T>
            {
                Results = results,
                PageNumber = (int)page,
                PageSize = (int)pageSize,
                TotalNumberOfPages = (int)totalPageCount,
                TotalNumberOfRecords = totalNumberOfRecords,
            };
        }
        catch (Exception)
        {
            return null;
        }
    }
    public static List<T> Sorting(SortOrder sortType, IEnumerable<T> searchResult, string colName)
    {
        var properties = typeof(T).GetProperties();
        var property = properties.FirstOrDefault(x => x.Name.Equals(colName, StringComparison.CurrentCultureIgnoreCase));

        if (property == null)
        {
            throw new ArgumentException($"Column '{colName}' does not exist in type '{typeof(T).Name}'.");
        }

        if (sortType == SortOrder.Ascending)
        {
            return searchResult.OrderBy(item => typeof(T).GetProperties().First(x => x.Name.Contains(colName, StringComparison.CurrentCultureIgnoreCase)).GetValue(item)).ToList();
        }
        else if (sortType == SortOrder.Descending)
        {
            return searchResult.OrderByDescending(item => typeof(T).GetProperties().First(x => x.Name.Contains(colName, StringComparison.CurrentCultureIgnoreCase)).GetValue(item)).ToList();
        }
        else
        {
            return searchResult.ToList();
        }
    }
}
