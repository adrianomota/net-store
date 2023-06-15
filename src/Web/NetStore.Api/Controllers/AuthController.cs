namespace NetStore.Api.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetStore.Auth.Application;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    [Route("token")]
    public async Task<IActionResult> Get()
    {
        var token = await Task.FromResult(TokenServices.GenerateToken("adriano", 1));
        return Ok(new { AccessToken = token});
    }
}
