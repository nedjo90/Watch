using Entities.Exceptions;
using Entities.Models;
using Main.Presentation.ActionFilter;
using Main.Presentation.ModelBinders;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DocumentStatus;

namespace Main.Presentation.Controllers;

[Route("api/documentstatus")]
[ApiController]
public class DocumentStatusController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public DocumentStatusController(IServiceManager serviceManager) => _serviceManager = serviceManager;

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
            await _serviceManager.DocumentStatusService.GetDocumentStatusByIdAsync(id, false);
        return Ok(documentStatusDto);
    }

    [HttpGet("collection/({ids})", Name = "DocumentStatusCollection")]
    public async Task<IActionResult> GetDocumentStatusCollection
        ([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        IEnumerable<DocumentStatusDto> documentStatusCollection =
            await _serviceManager.DocumentStatusService.GetDocumentStatusCollectionAsync(ids, false);
        return Ok(documentStatusCollection);
    }
    
    [HttpPost(Name = "CreateDocumentStatus")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateDocumentStatus
        ([FromBody]DocumentStatusForCreationDto? documentTypeForCreationDto)
    {
        DocumentStatusDto createdDocumentStatus =
            await _serviceManager.DocumentStatusService.CreateDocumentStatusAsync(documentTypeForCreationDto);
        return CreatedAtRoute("DocumentStatusById", new {Id = createdDocumentStatus.Id}, createdDocumentStatus);
    }
    
    [HttpPost("collection", Name = "CreateDocumentStatusCollection")]
    public async Task<IActionResult> CreateDocumentStatusCollection
        ([FromBody] IEnumerable<DocumentStatusForCreationDto> documentStatusForCreationCollection)
    {
        (IEnumerable<DocumentStatusDto> documentStatusCollection, string ids) result =
            await _serviceManager.DocumentStatusService.CreateDocumentStatusCollection(
                documentStatusForCreationCollection);
        return CreatedAtRoute("DocumentStatusCollection", new { result.ids}, result.documentStatusCollection);
    }

    [HttpDelete("{id:guid}", Name = "DeleteDocumentStatusById")]
    public async Task<IActionResult> DeleteDocumentStatus(Guid id)
    {
        await _serviceManager
            .DocumentStatusService
            .DeleteDocumentStatusAsync(id, false);
        return NoContent();
    }

    [HttpDelete("collection", Name = "DeleteDocumentStatusCollection")]
    public async Task<IActionResult> DeleteDocumentStatus
        ([FromBody]IEnumerable<DocumentStatusDto> documentStatusCollection)
    {
        await _serviceManager
            .DocumentStatusService
            .DeleteDocumentStatusCollectionAsync(documentStatusCollection, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateDocumentStatus")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateDocumentStatus
        (Guid id, [FromBody] DocumentStatusForUpdateDto documentStatusForUpdateDto)
    {
        await _serviceManager.DocumentStatusService
            .UpdateDocumentStatusAsync(id,documentStatusForUpdateDto, true);
        return NoContent();
    }

    [HttpPatch("{id:Guid}", Name = "PartiallyUpdateDocumentStatus")]
    public async Task<IActionResult> PartiallyUpdateDocumentStatus
        (Guid id, [FromBody]JsonPatchDocument<DocumentStatusForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            throw new NullObjectException($"patchDoc for {id}");
        (DocumentStatusForUpdateDto documentStatusToPatch, DocumentStatus entity)
            result = await _serviceManager.DocumentStatusService.GetDocumentStatusForPatchAsync(id, true);
        patchDoc.ApplyTo(result.documentStatusToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _serviceManager.DocumentStatusService.SaveChangesForPatchAsync(result.documentStatusToPatch,
            result.entity);
        return NoContent();
    }
}