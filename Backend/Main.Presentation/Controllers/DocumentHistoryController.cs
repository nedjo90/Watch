using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.DocumentHistory;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentHistoryController : ControllerBase
{
    private readonly IServiceManager _service;

    public DocumentHistoryController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<DocumentHistoryDto> documentHistoryDtos =
            await _service.DocumentHistoryService.GetAllAsync(false);
        return Ok(documentHistoryDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}