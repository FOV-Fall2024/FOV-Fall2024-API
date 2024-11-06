using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace FOV.Infrastructure.FirebaseDB;
internal class FCMTokenHandler
{
    private readonly static string authSecret = "49tixdsWTpWSVXWdgjfrJPRnvwSKIqUvzC8D1Z2v";
    private readonly static string basePath = "https://final-capstone-project-f8bdd-default-rtdb.asia-southeast1.firebasedatabase.app/";

    static IFirebaseClient _client;
    static IFirebaseConfig config = new FirebaseConfig()
    {
        AuthSecret = authSecret,
        BasePath = basePath
    };
    public static async Task<string> GetFCMTokenByUserID(Guid userId = new Guid())
    {
        _client = new FireSharp.FirebaseClient(config);
        FirebaseResponse response = await _client.GetAsync($@"FCMToken/{userId}");
        return response.StatusCode == System.Net.HttpStatusCode.BadRequest ? "NotUserloginInthis Account" : response.Body.ToString();
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
