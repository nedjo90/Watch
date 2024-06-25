using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserHistoryController : ControllerBase
{
    private readonly IServiceManager _service;

    public UserHistoryController(IServiceManager service)
    {
        _service = service;
    }
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}