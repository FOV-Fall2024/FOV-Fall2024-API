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
        var token = await FCMTokenHandler.GetFCMTokenByUserID(Guid.Parse("3c9bde0c-4842-4cfa-9f55-b49096cfbb70"));
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


