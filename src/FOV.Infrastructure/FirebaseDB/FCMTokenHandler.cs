using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace FOV.Infrastructure.FirebaseDB;
public static class FCMTokenHandler
{
    private readonly static string AuthSecret = "cSLxf0zRBKGntFFtcCSDquKnzb7DqznbkSNzxzpq";
    private readonly static string BasePath = "https://final-capstone-da026-default-rtdb.asia-southeast1.firebasedatabase.app/";

    static IFirebaseClient _client;
    static IFirebaseConfig config = new FirebaseConfig()
    {
        AuthSecret = AuthSecret,
        BasePath = BasePath
    };
    public static async Task<string> GetFCMTokenByUserID(Guid userId = new Guid())
    {
        _client = new FireSharp.FirebaseClient(config);
        FirebaseResponse response = await _client.GetAsync($@"FCMToken/{userId}");

        if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
        {
            return "NotUserloginInthis Account";
        }

        // Remove surrounding quotes if present
        return response.Body.Trim('"');
    }
    public static async Task AddFCMToken(Guid userId, string token)
    {
        _client = new FireSharp.FirebaseClient(config);
        FirebaseResponse response = await _client.SetAsync($@"FCMToken/{userId}", token);

        response.Body.ToString();
    }

    public static async Task DeleteFCMToken(Guid userId)
    {
        _client = new FireSharp.FirebaseClient(config);
        FirebaseResponse response = await _client.DeleteAsync($@"FCMToken/{userId}");

        response.Body.ToString();
    }

    public static async Task<string> GetFCMToken(Guid? userId = default)
    {
        _client = new FireSharp.FirebaseClient(config);
        FirebaseResponse response = await _client.GetAsync($@"FCMToken/{userId}");
        return response.Body.ToString();

    }

}
