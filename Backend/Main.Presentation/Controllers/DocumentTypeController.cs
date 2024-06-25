using Entities.Models;
using Main.Presentation.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.DocumentType;

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
    
    [HttpGet("{id:guid}", Name = "DocumentTypeById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        DocumentTypeDto? documentTypeDto = await _service.DocumentTypeService.GetByIdAsync(id, false);
        return Ok(documentTypeDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<DocumentTypeDto> documentTypeDtos =
            await _service.DocumentTypeService.GetAllAsync(false);
        return Ok(documentTypeDtos);
    }
    
    [HttpGet("collection",Name = "CollectionDocumentType")]
    public async Task<IActionResult> GetCollectionAsync([FromBody]IEnumerable<Guid?> ids)
    {
        IEnumerable<DocumentTypeDto> documentTypeDtos =
            await _service.DocumentTypeService.GetCollectionAsync(ids, false);
        return Ok(documentTypeDtos);
    }
    
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateAsync([FromBody]DocumentTypeForCreationDto documentTypeForCreationDto)
    {
        DocumentTypeDto documentTypeDto = await _service.DocumentTypeService.CreateAsync(documentTypeForCreationDto);
        return CreatedAtRoute("DocumentTypeById", new { Id = documentTypeDto.Id }, documentTypeDto);
    }
    
    [HttpPost("collection", Name = "CreateCollectionDocumentType")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCollectionAsync([FromBody]IEnumerable<DocumentTypeForCreationDto> documentTypeForCreation)
    {
        IEnumerable<DocumentTypeDto> documentTypeDtos =
            await _service.DocumentTypeService.CreateCollectionAsync(documentTypeForCreation);
        List<Guid?> ids = documentTypeDtos.Select(e => e.Id).ToList();
        return Created(Url.Link("CollectionDocumentType", null),documentTypeDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}