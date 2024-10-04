
using StackExchange.Redis;

namespace FOV.Infrastructure.FCM;
internal class FCMTokenService : IFCMTokenService
{
    private readonly IDatabase _database;
    public FCMTokenService(IDatabase database)
    {
        _database = database;
    }
    public string GetFCMToken(Guid userId)
    {
        throw new NotImplementedException();
    }

    public List<string> GetFCMTokenList()
    {
        throw new NotImplementedException();
    }

    public async ValueTask SaveFCMToken(Guid userId, string token)
    {
        await _database.StringSetAsync(userId.ToString(), token);
    }
}
