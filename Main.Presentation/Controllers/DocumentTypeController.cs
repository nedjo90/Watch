using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;

namespace Main.Presentation.Controllers;

[Route("api/documenttypes")]
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
        IEnumerable<DocumentTypeDto> companies = _service.DocumentTypeService.GetAllDocumentTypes(false);
        return Ok(companies);
    }

    [HttpGet("{id:guid}", Name = "DocumentTypeById")]
    public IActionResult GetDocumentType(Guid id)
    {
        var documentType = _service.DocumentTypeService.GetDocumentType(id, false);
        return Ok(documentType);
    }

    [HttpPost]
    public IActionResult CreateDocumentType
        ([FromBody] DocumentTypeForCreationDto documentType)
    {
        if (documentType is null)
            return BadRequest("DocumentTypeForCreationDto object is null");
        var createdDocumentType = _service.DocumentTypeService.CreateDocumentType(documentType);
        return CreatedAtRoute("DocumentTypeById", new { Id = createdDocumentType.Id }, createdDocumentType);
    }
}