using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.DocumentTypeHistory;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentTypeHistoryController : ControllerBase 
{
    private readonly IServiceManager _service;

    public DocumentTypeHistoryController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<DocumentTypeHistoryDto> documentTypeHistoryDtos = 
                await _service.DocumentTypeHistoryService.GetAllAsync(false);
        return Ok(documentTypeHistoryDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}