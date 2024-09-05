using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elastic.Clients.Elasticsearch;
using FOV.Domain.Common;
using FOV.Infrastructure.Configuration;
using FOV.Infrastructure.Elastic.IService;
using Microsoft.Extensions.Options;

namespace FOV.Infrastructure.Elastic.Service;
public class ElasticGenericService<TEntity> : IElasticGenericService<TEntity> where TEntity : ElasticEntity
{
    private readonly ElasticsearchClient _client;
    private readonly ElasticSettings _elasticSettings;

    public ElasticGenericService(IOptions<ElasticSettings> optionsMonitor)
    {
        _elasticSettings = optionsMonitor.Value;
        var settings = new ElasticsearchClientSettings(new Uri(_elasticSettings.Url)).DefaultIndex(_elasticSettings.DefaultIndex);

        _client = new ElasticsearchClient(settings);
    }
    public async Task<bool> AddOrUpdate(TEntity entity)
    {
        var response = await _client.IndexAsync(entity, idx => idx.Index(_elasticSettings.DefaultIndex).OpType(OpType.Index));

        return response.IsValidResponse;
    }


    public async Task<bool> AddOrUpdateBulk(IEnumerable<TEntity> entities, string indexName)
    {
        var response = await _client.BulkAsync(x => x.Index(_elasticSettings.DefaultIndex).UpdateMany(entities, (ud, u) => ud.Doc(u).DocAsUpsert(true)));


        return response.IsValidResponse;
    }

    public async Task CreateIndexIfNotExitsAsync(string indexName)
    {
        if (!_client.Indices.Exists(indexName).Exists)
            await _client.Indices.CreateAsync(indexName);
    }

    public async Task<TEntity> Get(string key)
    {
        var response = await _client.GetAsync<TEntity>(key, g => g.Index(_elasticSettings.DefaultIndex));

        return response.Source;
    }

    public async Task<List<TEntity>> GetAll()
    {
        var response = await _client.SearchAsync<TEntity>(g => g.Index(_elasticSettings.DefaultIndex));

        return response.IsValidResponse ? response.Documents.ToList() : default;
    }

    public async Task<bool> Remove(string key)
    {
        var response = await _client.DeleteAsync<TEntity>(key,g => g.Index(_elasticSettings.DefaultIndex));
        return response.IsValidResponse;
    }

    public async Task<long?> RemoveAll()
    {
        var response = await _client.DeleteByQueryAsync<TEntity>(x => x.Indices(_elasticSettings.DefaultIndex));
        return response.Deleted;
    }
}
