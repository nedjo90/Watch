using Main.Presentation.ActionFilter;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Login;

namespace Main.Presentation.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuthenticationController(IServiceManager service)
    {
        _service = service;
    }

    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
    {
        if (!await _service.AuthenticationService.ValidateUser(user))
            return Unauthorized();
        TokenDto tokenDto = await _service.AuthenticationService.CreateToken(true);
        return Ok(tokenDto);
    }
    
    
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        IdentityResult result =
            await _service.AuthenticationService.RegisterUser(userForRegistrationDto);
        if (!result.Succeeded)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        return StatusCode(201);
    }
    
    [HttpPost("collection")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUserCollection([FromBody]IEnumerable<UserForRegistrationDto> userForRegistrationDto)
    {
        Dictionary<string, Dictionary<string, Dictionary<string, string>>> results =
            await _service.AuthenticationService.RegisterUserCollection(userForRegistrationDto);
        if (results["Failed"].Count != 0)
            return BadRequest(results);
        return StatusCode(201);
    }
}