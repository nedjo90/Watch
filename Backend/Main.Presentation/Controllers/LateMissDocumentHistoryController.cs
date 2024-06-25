using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.LateMissDocumentHistory;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LateMissDocumentHistoryController : ControllerBase
{
    private readonly IServiceManager _service;

    public LateMissDocumentHistoryController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<LateMissDocumentHistoryDto> lateMissDocumentHistoryDtos = 
            await _service.LateMissDocumentHistoryService.GetAllAsync(false);
        return Ok(lateMissDocumentHistoryDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}