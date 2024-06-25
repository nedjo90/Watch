using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.LateMissHistory;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LateMissHistoryController : ControllerBase
{
    private readonly IServiceManager _service;

    public LateMissHistoryController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<LateMissHistoryDto> lateMissHistoryDtos = 
            await _service.LateMissHistoryService.GetAllAsync(false);
        return Ok(lateMissHistoryDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}