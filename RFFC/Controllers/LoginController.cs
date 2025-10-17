using Microsoft.AspNetCore.Mvc;
using RFFC.DTO_s;
using RFFC.Interfaces;

namespace RFFC.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _loginService.LoginAsync(dto, cancellationToken);
        return Ok(result);
    }
}
