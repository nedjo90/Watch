using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.LateMissTypeHistory;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LateMissTypeHistoryController : ControllerBase
{
    private readonly IServiceManager _service;

    public LateMissTypeHistoryController(IServiceManager service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<LateMissTypeHistoryDto> documentHistoryDtos =
            await _service.LateMissTypeHistoryService.GetAllAsync(false);
        return Ok(documentHistoryDtos);
    }
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}