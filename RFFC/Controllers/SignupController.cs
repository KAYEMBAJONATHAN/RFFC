using Microsoft.AspNetCore.Mvc;
using RFFC.DTO_s;
using RFFC.Interfaces;

namespace RFFC.Controllers;

public class SignupController
{

    [ApiController]
    [Route("api/[controller]")]
    public class SignupContoller : ControllerBase
    {
        private readonly ISignupService _signupService;

        public SignupContoller(ISignupService signupService)
        {
            _signupService = signupService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(SignupDto dto, CancellationToken cancellationToken)
        {
            var result = await _signupService.SignupAsync(dto, cancellationToken);
            return Ok(result);
        }
    }
}
