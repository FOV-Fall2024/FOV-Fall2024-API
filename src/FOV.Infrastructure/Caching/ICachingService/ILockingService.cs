namespace FOV.Infrastructure.Caching.ICachingService;
public interface ILockingService
{
    public Task<bool> AcquireLockAsync();

    public Task ReleaseLockAsync();
}
