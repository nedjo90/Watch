using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;
using Shared.DocumentStatus;
using Shared.DocumentType;

namespace Main.Presentation.Controllers;

[Route("api/documentstatus")]
[ApiController]
public class DocumentStatusController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public DocumentStatusController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet(Name = "AllDocumentStatus")]
    public async Task<IActionResult> GetAllDocumentStatus()
    {
        IEnumerable<DocumentStatusDto> documentStatusDto =
            await _serviceManager.DocumentStatusService.GetAllDocumentStatusAsync(false);
        return Ok(documentStatusDto);
    }

    [HttpGet("{id:guid}" ,Name = "DocumentStatusById")]
    public async Task<IActionResult> GetDocumentStatus(Guid id)
    {
        DocumentStatusDto documentStatusDto =
            await _serviceManager.DocumentStatusService.GetDocumentById(id, false);
        return Ok(documentStatusDto);
    }
    
    [HttpPost(Name = "CreateDocumentStatus")]
    public async Task<IActionResult> CreateDocumentStatus
        ([FromBody]DocumentStatusForCreationDto? documentTypeForCreationDto)
    {
        DocumentStatusDto createdDocumentStatus =
            await _serviceManager.DocumentStatusService.CreateDocumentStatusAsync(documentTypeForCreationDto);
        return CreatedAtRoute("DocumentStatusById", new {Id = createdDocumentStatus.Id}, createdDocumentStatus);
    }
}