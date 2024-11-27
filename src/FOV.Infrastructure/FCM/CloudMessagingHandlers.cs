using System;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace FOV.Infrastructure.FCM;

public static class CloudMessagingHandlers
{
    // Ensure FirebaseApp is initialized only once
    static CloudMessagingHandlers()
    {
        if (FirebaseApp.DefaultInstance == null)
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("src/fov-fall2024-firebase-adminsdk-oc21j-7f499b5d25.json"),
            });
        }
    }

    /// <summary>
    /// Sends a push notification to the specified token.
    /// </summary>
    /// <param name="token">The target device's registration token.</param>
    /// <param name="title">The notification title.</param>
    /// <param name="body">The notification body.</param>
    /// <returns>An asynchronous task representing the operation.</returns>
    public static async Task SendPushNotification(string token, string title, string body)
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

        try
        {
            // Send a message to the device corresponding to the provided registration token.
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            Console.WriteLine("Successfully sent message: " + response);
        }
        catch (Exception ex)
        {
            // Handle and log any exceptions here
            Console.WriteLine("Error sending message: " + ex.Message);
        }
    }
}
