using System.Net;
using System.Text;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;

namespace FOV.Infrastructure.FCM;
public class CloudMessagingHandlers
{
    public CloudMessagingHandlers()
    {
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile("src/fov-fall2024-firebase-adminsdk-oc21j-7f499b5d25.json"),
        });
    }

    public async static Task SendPushNotification(string token, string title, string body)
    {
        var message = new Message()
        {
            Token = token,
            Notification = new Notification
            {
                Title = title,
                Body = body,
            },
        };

        // Send a message to the device corresponding to the provided registration token.
        string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
        Console.WriteLine("Successfully sent message: " + response);
    }
}

