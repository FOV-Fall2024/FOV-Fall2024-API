using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Api.Gax.ResourceNames;

namespace FOV.Infrastructure.FirebaseDB;
internal class NotificationHandler
{
    private readonly static string authSecret = "49tixdsWTpWSVXWdgjfrJPRnvwSKIqUvzC8D1Z2v";
    private readonly static string basePath = "https://final-capstone-project-f8bdd-default-rtdb.asia-southeast1.firebasedatabase.app/";

    static IFirebaseClient _client;
    static IFirebaseConfig config = new FirebaseConfig()
    {
        AuthSecret = authSecret,
        BasePath = basePath
    };

    public static async Task NewOrder(DateTime dateTime, string Table)
    {
        string notification = $"New order placed! Order ID. " +
                       $"at {Table}.";
        _client = new FireSharp.FirebaseClient(config);

        // Update existing message
        FirebaseResponse response = await _client.SetAsync("Messages/message", notification);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            Console.WriteLine("Message updated successfully!");
        }
        else
        {
            Console.WriteLine($"Error updating message: {response.StatusCode}");
        }
    }

    public static async Task ServeOrder( string table)
    {
        string notification = $"Order ready! The food is prepared and ready to be served to the customer  at {table} ";
        _client = new FireSharp.FirebaseClient(config);

        // Update existing message
        FirebaseResponse response = await _client.SetAsync("Messages/message", notification);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            Console.WriteLine("Message updated successfully!");
        }
        else
        {
            Console.WriteLine($"Error updating message: {response.StatusCode}");
        }
    }
}
