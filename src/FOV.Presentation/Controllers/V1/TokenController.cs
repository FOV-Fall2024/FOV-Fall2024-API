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
}


