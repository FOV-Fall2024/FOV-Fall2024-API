using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace FOV.Infrastructure.Caching.CachingService;
public class LockingHandler : IDisposable
{
    private readonly IDatabase _database;
    private readonly string _lockKey;
    private readonly string _lockValue;
    private readonly TimeSpan _expiry;
    private bool _lockAcquired;

    public LockingHandler(IDatabase database, string lockKey, TimeSpan expiry)
    {
        _database = database;
        _lockKey = lockKey;
        _lockValue = Guid.NewGuid().ToString();
        _expiry = expiry;
    }


    public async Task<bool> AcquireLockAsync()
    {
        _lockAcquired = await _database.StringSetAsync(_lockKey, _lockValue, _expiry, When.NotExists);
        return _lockAcquired;
    }

    public async Task ReleaseLockAsync()
    {
        if (_lockAcquired)
        {
            var tran = _database.CreateTransaction();
            tran.AddCondition(Condition.StringEqual(_lockKey, _lockValue));
            _ = tran.KeyDeleteAsync(_lockKey);
            await tran.ExecuteAsync();
        }
    }
    public void Dispose()
    {
        if (_lockAcquired)
        {
            ReleaseLockAsync().GetAwaiter().GetResult();
        }
    }
}

