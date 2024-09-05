using FOV.Infrastructure.Caching.ICachingService;
using StackExchange.Redis;

namespace FOV.Infrastructure.Caching.CachingService;
internal class StateCacheManagerService : IStateCacheManagerService
{
    private readonly IDatabase _database;
    public StateCacheManagerService(IDatabase database)
    {
        _database = database;
    }

    private static string GetLockKey(Guid tableId) => $"{tableId}_lockTable";
    public async ValueTask<bool> CheckState(Guid tableId)
    {
        var state = await _database.StringGetAsync(GetLockKey(tableId));

        return state == State(1);
    }

    public async ValueTask SetServiceState(Guid tableId) => await _database.StringSetAsync(GetLockKey(tableId), State(1));



    static string State(int stateNum) => stateNum switch
    {
        1 => "Locking",
        _ => throw new NotImplementedException()
    };
}
