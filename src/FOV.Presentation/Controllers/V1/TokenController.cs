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
        var token = await FCMTokenHandler.GetFCMTokenByUserID(Guid.Parse("f6d88c17-ed85-4c9a-bb45-a7c02e97b038"));
        await CloudMessagingHandlers.SendNotification(token, "ccc", "ccc");
        
        return Ok(token);
    }
    [HttpGet("test-to")]
    public async Task<IActionResult> TestToken()
    {
        string token = await FCMTokenHandler.GetFCMToken();
        return Ok(token);
    }
}


