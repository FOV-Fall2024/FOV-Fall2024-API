using FOV.Infrastructure.FCM;
using FOV.Infrastructure.FirebaseDB;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class FCMTokenController : DefaultController
{

    [HttpPost("user/{userId}/token/{tokenId}")]
    public async Task<IActionResult> AddToken(Guid userId,string tokenId) 
    {
        await FCMTokenHandler.AddFCMToken(userId,tokenId);
        return Ok();
    }

    [HttpGet("test-notify")]
    public async Task<IActionResult> TestNotify()
    {
        string token = await CloudMessagingHandlers.TakeToken();
        await CloudMessagingHandlers.SendNotification("dFugB9D5Sq6OCEXHAebcra:APA91bGgTbesgfIGB72YM_gusaudL-8aICZbPbH5W-3XsSwWyuY9RD6-PlcJaoLYvGiMVdLT055RerUYVYesdmfDZo2j04k3lbthS1QRWfQ2qt0VBgpPHZU", "hihi","hihi");
        return Ok(token);
    }
}


