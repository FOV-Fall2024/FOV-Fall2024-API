namespace FOV.Infrastructure.Caching.ICachingService;
public interface IStateCacheManagerService
{
    ValueTask SetServiceState(Guid tableId);

    ValueTask<bool> CheckState(Guid tableId);

}
