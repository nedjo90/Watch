using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.LateMissStatusHistory;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LateMissStatusHistoryController : ControllerBase
{
    private readonly IServiceManager _service;

    public LateMissStatusHistoryController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<LateMissStatusHistoryDto> documentHistoryDtos =
            await _service.LateMissStatusHistoryService.GetAllAsync(false);
        return Ok(documentHistoryDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}