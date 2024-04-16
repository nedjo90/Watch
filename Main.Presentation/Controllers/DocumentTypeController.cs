using Entities.Exceptions;
using Entities.Models;
using Main.Presentation.ModelBinders;
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

    [HttpGet("collection/({documentTypes})", Name = "DocumentTypeCollection")]
    public IActionResult GetDocumentTypeCollection
    ([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
    {
        IEnumerable<DocumentTypeDto> documentTypeDtos = _service.DocumentTypeService.GetByIds(ids, false);
        return Ok(documentTypeDtos);
    }
    
    [HttpPost]
    public IActionResult CreateDocumentType
        ([FromBody] DocumentTypeForCreationDto? documentType)
    {
        if (documentType is null)
            return BadRequest("DocumentTypeForCreationDto object is null");
        var createdDocumentType = _service.DocumentTypeService.CreateDocumentType(documentType);
        return CreatedAtRoute("DocumentTypeById", new { Id = createdDocumentType.Id }, createdDocumentType);
    }
    
    [HttpPost("collection")]
    public IActionResult CreateDocumentTypeCollection
        ([FromBody]IEnumerable<DocumentTypeForCreationDto> documentTypeCollection)
    {
        (IEnumerable<DocumentTypeDto> documentTypeDtos, string ids) result = 
            _service.DocumentTypeService.CreateDocumentTypeCollection(documentTypeCollection);

        //return Ok(createdDocumentTypeCollection);
        return CreatedAtRoute
            ("DocumentTypeCollection", new { result.ids }, result.documentTypeDtos);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteDocumentType(Guid id)
    {
        _service.DocumentTypeService.DeleteDocumentType(id, false);
        return NoContent();
    }

    [HttpDelete("collection")]
    public IActionResult DeleteDocumentTypeCollection([FromBody] IEnumerable<DocumentTypeDto> documentTypes)
    {
        _service.DocumentTypeService.DeleteDocumentTypeCollection(documentTypes, false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateDocumentType(Guid id, [FromBody] DocumentTypeForUpdateDto documentTypeForUpdateDto)
    {
        if (documentTypeForUpdateDto is null)
            throw new NullObjectException(documentTypeForUpdateDto.ToString());
        _service.DocumentTypeService.UpdateDocumentType(id, documentTypeForUpdateDto, true);
        return NoContent();
    }
}