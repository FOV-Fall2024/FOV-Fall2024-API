using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FOV.Infrastructure.FCM;

public static class CloudMessagingHandlers
{
    // Ensure FirebaseApp is initialized only once
    //static CloudMessagingHandlers()
    //{
    //    if (FirebaseApp.DefaultInstance == null)
    //    {
    //        FirebaseApp.Create(new AppOptions()
    //        {
    //            Credential = GoogleCredential.FromFile("C:\\Code\\FOV-Fall2024-API\\src\\fov-fall2024-firebase-adminsdk-oc21j-7f499b5d25.json"),
    //        });

    //    }
    //}
    private static string jsonString = @"{
  ""type"": ""service_account"",
  ""project_id"": ""final-capstone-da026"",
  ""private_key_id"": ""56ee3b182504a1dc92e69c2bff74baeac017ecd5"",
  ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDYX77ctxRm3MaS\njuGs4SHeqzKcHK8AOeL3xP4f4yXAOPrj+PGurBJe90gVcklx8hv1o/NOsKwWzKWt\nuFOXyo9ZgNYEycwAUeFFExwj17YKmMsHRzCmJ1He6RL/9KittlnZLkZ8KPBj9j43\ngEDXUQwID/nfXk96VwJlYQ5G9go2lW2fT79dxWjJT/mvCY4mWIVZ09hhH+teJgDN\nCF8jED7N0h3KD8nbpCSxq+hXESVfGpK12qihQsU2SMhi+t6mbmXKbnLrqEJq7eES\nCJEwtsz7PAaW9p17KsaSe2PGfhn5i6fNEMiaRwtYydkybHJyFebewBLa7/AbMDXf\nR7Gg9YK3AgMBAAECggEAFfwshXqovQbjulKARbOeYGSewNP9SBWZpTlD5POMi2p+\nu5k43VmoiDOyBFPXeJd0FdJxz2YOJkbm8q7O95ZiWGLJ3DSw4LtxGzak3lN1sL/z\nqSqnm8pU/ERMZOt0FCp6GKImEUmLm2ySx8rlS7t1cIBHEFYh1zluCeUBsV4gjYkT\nc+g2dbGHnyAUa/mNOArXcIipzBsGiWtznLFWnUI7dzAR8XiiD36tw5eWGKkzG1Cw\ncjNU7MjxiWrWi93bQoRyinzINcGINp8L19jlLv/qqJxRo0MwZayH7AOTKA5g4wpD\nsFFFJNIy5yyqsdeg/T3LkqVId7AdEDudme5LC4ZL2QKBgQD4SlwzuqSpEqIz8iwk\nXhn5YvFgH9OZsF05HpjY8tbuzOpmOo/gOYuizW9xBPIcmtbW1AC+k2IOZwVRboUZ\nVmi2QKQOBvwsYcmdGo1xcOlI3oZyc8cfxlS7BMnUq1LDfdcv+QIxVswciDVf67O/\nS2OQqlTQt9fIQCkj1xBWLpt0+wKBgQDfF68jnFy1sWKN8/6yzamiP2LwBIZOgmGY\nMn5QOmrgsP9a7Xk9yFuVJEVR+2E0pnCRrLrYth1d39GOTUoEMWS3sOA9947oeTJR\ndvjV3Q4TuC21D9D4RZTSIqVTwzA48SVtduiDbEGfh0iNK7ihIDU1PbpfR2bcTKSB\nf9H7EvVkdQKBgQDpMmYQy771cSPZKB4fdiZtHWnZP2stEQEtsbgbI1GNbfbFV0Fk\ndofYu5xsiRmgliksEmg0lhZlsorDJctqtcaZTnMHHbZhNOL4ZETug/8HSsD55BXk\nmRFhqaiqztJn+9xNGVHe50fDkIaY9baX94WnDOOmONU5JlG9cLPOTe4CWwKBgFek\nJEenG7y9LOx7WCnCJcv5ftKv1FtvWQvDel/mMyqGHisIc8LTvTbAAwOL78oRQNPZ\nuaV9FdhVHyv6LQOsq9aGA/IUGO42/o+GX4cUynzws/QXfI6sNyS+O5jGa2FTStLQ\nDdPjaXxUVyoubN/PmVeLInZfxIbzDQVaw5ERB5opAoGBAMY5JO4lgyg0m8e9TiBs\npCD4bDqDdP6/rPuziIfnqY0XG/s+k3Wg18IADYDVN3u7JPasZq92A4hXj8yWjqQh\nNujXQXfBGFe59UWASF3kd4w0XzS87bXAtea3Ly/r9tJok3zlfAVYGw6bUHm5ooe9\nn3fejTBHNis6Sxks0WFMUZhb\n-----END PRIVATE KEY-----\n"",
  ""client_email"": ""firebase-adminsdk-huo98@final-capstone-da026.iam.gserviceaccount.com"",
  ""client_id"": ""110931718757360400422"",
  ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
  ""token_uri"": ""https://oauth2.googleapis.com/token"",
  ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
  ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-huo98%40final-capstone-da026.iam.gserviceaccount.com"",
  ""universe_domain"": ""googleapis.com""
}


";
    public static async Task<string> TakeToken()
    {
        try
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonString);
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                GoogleCredential credential = GoogleCredential.FromStream(stream).CreateScoped("https://www.googleapis.com/auth/firebase.messaging");
                var token = await credential.UnderlyingCredential.GetAccessTokenForRequestAsync();

                return token;
            }


        }
        catch (Exception ex)
        {
            Console.WriteLine("Error obtaining OAuth token: " + ex.Message);
            throw;
        }
    }

    /// <summary>
    /// Sends a push notification to the specified token.
    /// </summary>
    /// <param name="token">The target device's registration token.</param>
    /// <param name="title">The notification title.</param>
    /// <param name="body">The notification body.</param>
    /// <returns>An asynchronous task representing the operation.</returns>
    public static async Task SendNotification(string token, string title, string body)
    {
        using HttpClient httpClient = new();
        // Construct the JSON payload
        string json = @$"{{
    ""message"": {{
        ""token"": ""{token}"",
        ""notification"": {{
            ""title"": ""{title}"",
            ""body"": ""{body}""
        }}
    }}
}}";


        // Configure the HTTP client headers
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {await TakeToken()}");
        //  httpClient.DefaultRequestHeaders.TryAddWithoutValidation("SenderId", "376507364132");

        // Send the POST request
        HttpResponseMessage responseMessage = await httpClient.PostAsync(
            "https://fcm.googleapis.com/v1/projects/final-capstone-da026/messages:send",
            new StringContent(json, Encoding.UTF8, "application/json")
        );

        // Read the response body
        string responseBody = await responseMessage.Content.ReadAsStringAsync();

        // Optionally handle the response
        if (responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Notification sent successfully: {responseBody}");
        }
        else
        {
            Console.WriteLine($"Failed to send notification. Status: {responseMessage.StatusCode}, Response: {responseBody}");
        }
    }

}
