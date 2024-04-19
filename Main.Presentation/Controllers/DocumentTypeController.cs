using Entities.Exceptions;
using Entities.Models;
using Main.Presentation.ActionFilter;
using Main.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;
using Microsoft.AspNetCore.JsonPatch;
using Entities.LinkModels;
using Shared.DocumentType;
using Shared.RequestFeatures;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace Main.Presentation.Controllers;

[Route("api/documenttypes")]
[ApiController]
public class DocumentTypeController : ControllerBase
{
    private readonly IServiceManager _service;

    public DocumentTypeController(IServiceManager service) => _service = service;
    
    [HttpGet(Name = "AllDocumentTypes")]
    public async Task<IActionResult> GetDocumentTypes()
    {
        IEnumerable<DocumentTypeDto> companies = 
            await _service.DocumentTypeService.GetAllDocumentTypesAsync( false);
        return Ok(companies);
    }
    
    [HttpGet("page", Name = "AllDocumentTypesPaging")]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    public async Task<IActionResult> GetDocumentTypesPaging([FromQuery]DocumentTypeParameters documentTypeParameters)
    {
        LinkParameters linkParams =
            new LinkParameters(documentTypeParameters, HttpContext);
        
        (LinkResponse linkResponse, MetaData metadata) pagedResult = 
            await _service.DocumentTypeService
                .GetAllDocumentTypesPagingAsync(linkParams, false);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metadata));
        return pagedResult.linkResponse.HasLinks ?
                Ok(pagedResult.linkResponse.LinkedEntities)
                : Ok(pagedResult.linkResponse.ShapedEntities);
    }
    
    [HttpGet("{id:guid}", Name = "DocumentTypeById")]
    public async Task<IActionResult> GetDocumentType(Guid id)
    {
        DocumentTypeDto documentType = 
            await _service.DocumentTypeService.GetDocumentTypeAsync(id, false);
        return Ok(documentType);
    }

    [HttpGet("collection/({ids})", Name = "DocumentTypeCollection")]
    public async Task<IActionResult> GetDocumentTypeCollection
    ([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
    {
        IEnumerable<DocumentTypeDto> documentTypeDtos =
            await _service.DocumentTypeService.GetByIdsAsync(ids, false);
        return Ok(documentTypeDtos);
    }
    
    [HttpPost(Name = "CreateDocumentType")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateDocumentType
        ([FromBody] DocumentTypeForCreationDto? documentType)
    {
        DocumentTypeDto createdDocumentType = 
            await _service.DocumentTypeService.CreateDocumentTypeAsync(documentType);
        return CreatedAtRoute("DocumentTypeById", new { Id = createdDocumentType.Id }, createdDocumentType);
    }
    
    [HttpPost("collection", Name = "CreateCollectionOfDocumentTypes")]
    public async Task<IActionResult> CreateDocumentTypeCollection
        ([FromBody]IEnumerable<DocumentTypeForCreationDto> documentTypeCollection)
    {
        (IEnumerable<DocumentTypeDto> documentTypeDtos, string ids) result = 
            await _service.DocumentTypeService.CreateDocumentTypeCollectionAsync(documentTypeCollection);
        return CreatedAtRoute
            ("DocumentTypeCollection", new { result.ids }, result.documentTypeDtos);
    }

    [HttpDelete("{id:guid}", Name = "DeleteDocumentTypeById")]
    public async Task<IActionResult> DeleteDocumentType(Guid id)
    {
        await _service.DocumentTypeService.DeleteDocumentTypeAsync(id, false);
        return NoContent();
    }

    [HttpDelete("collection", Name = "DeleteCollectionOfDocumentTypes")]
    public async Task<IActionResult> DeleteDocumentTypeCollection
        ([FromBody] IEnumerable<DocumentTypeDto> documentTypes)
    {
        await _service.DocumentTypeService.DeleteDocumentTypeCollectionAsync(documentTypes, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateDocumentType")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateDocumentType
        (Guid id, [FromBody] DocumentTypeForUpdateDto documentTypeForUpdateDto)
    {
        await _service.DocumentTypeService
            .UpdateDocumentTypeAsync(id, documentTypeForUpdateDto, true);
        return NoContent();
    }

    [HttpPatch("{id:guid}", Name = "PartiallyUpdateDocumentType")]
    public async Task<IActionResult> PartiallyUpdateDocumentType
        (Guid id, [FromBody]JsonPatchDocument<DocumentTypeForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            throw new NullObjectException($"patchDoc for {id}");
        (DocumentTypeForUpdateDto documentTypeToPatch, DocumentType documentTypeEntity) result =
            await _service.DocumentTypeService
                .GetDocumentTypeForPatchAsync(id, true);
        patchDoc.ApplyTo(result.documentTypeToPatch, ModelState);
        TryValidateModel(result.documentTypeToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.DocumentTypeService.SaveChangesForPatchAsync(result.documentTypeToPatch, result.documentTypeEntity);
        return NoContent();
    }

    
}