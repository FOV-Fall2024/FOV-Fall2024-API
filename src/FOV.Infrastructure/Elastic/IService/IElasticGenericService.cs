using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;

namespace FOV.Infrastructure.Elastic.IService;
public interface IElasticGenericService<T> where T : ElasticEntity
{
    Task CreateIndexIfNotExitsAsync(string indexName);

    Task<bool> AddOrUpdate(T entity);

    Task<bool> AddOrUpdateBulk(IEnumerable<T> entities,string indexName);

    Task<T> Get(string key);

    Task<List<T>> GetAll();

    Task<bool> Remove(string key);

    Task<long?> RemoveAll();
}
