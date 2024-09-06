using FOV.Domain.ElasticEntities;
using FOV.Infrastructure.Elastic.IService;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class TestELkController : DefaultController
{
    private readonly ILogger<TestELkController> _logger;
    private readonly IUserElasticService _userElasticService;

    public TestELkController(ILogger<TestELkController> logger,
        IUserElasticService userElasticService)
    {
        _userElasticService = userElasticService;
        _logger = logger;
    }

    [HttpPost("create-index")]
    public async Task<IActionResult> CreateIndex(string IndexName)
    {
        await _userElasticService.CreateIndexIfNotExitsAsync(IndexName);
        return Created();
    }

    [HttpPost("add-user")]
    public async Task<IActionResult> AddUser([FromBody] UserDomain user)
    {
        var result = await _userElasticService.AddOrUpdate(user);
        return result ? Ok() : BadRequest();
    }

    [HttpPost("update-user")]
    public async Task<IActionResult> UpdateUser([FromBody] UserDomain user)
    {
        var result = await _userElasticService.AddOrUpdate(user);
        return result ? Ok() : BadRequest();
    }


    [HttpGet("get-user/{key}")]
    public async Task<IActionResult> GetUser(string key)
    {
        var user = await _userElasticService.Get(key);
        return user != null ? Ok(user) : NotFound();
    }

    [HttpGet("get-all-users")]
    public async Task<IActionResult> GetUsers()
    {
        var user = await _userElasticService.GetAll();
        return user != null ? Ok(user) : NotFound();
    }

    [HttpDelete("delete-user/{key}")]
    public async Task<IActionResult> DeleteUser(string key)
    {
        var result = await _userElasticService.Remove(key);
        return result != null ? Ok("Deleted Successfully") : NotFound();
    }
}
