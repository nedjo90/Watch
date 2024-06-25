using Main.Presentation.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.Authentication;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuthenticationController(IServiceManager service)
    {
        _service = service;
    }
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto
        userForRegistration)
    {
        var result = await
            _service.AuthenticationService.RegisterUser(userForRegistration);
        if (result.Succeeded) return StatusCode(201);
        foreach (var error in result.Errors)
        {
            ModelState.TryAddModelError(error.Code, error.Description);
        }
        return BadRequest(ModelState);
    }
    
    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto
        user)
    {
        if (!await _service.AuthenticationService.ValidateUser(user))
            return Unauthorized();
        TokenDto tokenDto = await _service.AuthenticationService
            .CreateToken(populateExp: true);
        return Ok(tokenDto);
    }
}