using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentTypeController : ControllerBase
{
    private readonly IServiceManager _service;

    public DocumentTypeController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetDocumentTypes()
    {
        try
        {
            IEnumerable<DocumentType> companies = _service.DocumentTypeService.GetAllDocumentTypes(false);
            return Ok(companies);
        }
        catch
        {
            return StatusCode(500, "Internal server error");
        }
    }
}