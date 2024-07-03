using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.User;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IServiceManager _service;

    public UserController(IServiceManager service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetUserInfo()
    {
        UserInfoDto userInfoDto =  await _service.UserService.GetCurrentUserInfo();
        return Ok(userInfoDto);
    }
    
    [HttpGet("roles")]
    public async Task<IActionResult> GetCurrentUserRoles()
    {
        IList<string> roles = await _service.UserService.GetCurrentUserRoles();
        return Ok(roles);
    }
    
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}