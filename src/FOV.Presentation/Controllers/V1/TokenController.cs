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
        await CloudMessagingHandlers.SendNotification("fwUMoOjARDS4AcpLmVNqYB:APA91bE8UzCxCMP4MY1SVIylY2Zj36nf6rLwY40uly5RthF96nZ1N_e-2LlmhDC5wUg0gsXmdm_GXeln5lad11nu6NEr3YkMsp2dy8cvreF8fr163Yxyt6w", "hihi","hihi");
        return Ok(token);
    }
}


