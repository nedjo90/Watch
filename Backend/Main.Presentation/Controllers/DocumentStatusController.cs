using Main.Presentation.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.DocumentStatus;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentStatusController : ControllerBase
{
    private readonly IServiceManager _service;

    public DocumentStatusController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("{id:Guid}", Name = "DocumentStatusById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        DocumentStatusDto? documentStatusDto = await _service.DocumentStatusService.GetByIdAsync(id, false);
        return Ok(documentStatusDto);
    }
    
    [HttpGet(Name = "AllDocumentStatus")]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<DocumentStatusDto> documentStatusDtos =
            await _service.DocumentStatusService.GetAllAsync(false);
        return Ok(documentStatusDtos);
    }
    
    [HttpGet("collection",Name = "CollectionDocumentStatus")]
    public async Task<IActionResult> GetCollectionAsync([FromBody]IEnumerable<Guid?> ids)
    {
        IEnumerable<DocumentStatusDto> documentStatusDtos =
            await _service.DocumentStatusService.GetCollectionAsync(ids, false);
        return Ok(documentStatusDtos);
    }
    
    [HttpPost(Name = "CreateDocumentStatus")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateAsync([FromBody]DocumentStatusForCreationDto documentStatusForCreationDto)
    {
        DocumentStatusDto documentStatusDto =
            await _service.DocumentStatusService.CreateAsync(documentStatusForCreationDto);
        return CreatedAtRoute("DocumentStatusById", new { Id = documentStatusDto.Id }, documentStatusDto);
    }
    
    [HttpPost("collection", Name = "CreateCollectionDocumentStatus")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCollectionAsync([FromBody]IEnumerable<DocumentStatusForCreationDto> documentStatusForCreation)
    {
        IEnumerable<DocumentStatusDto> documentStatusDtos =
            await _service.DocumentStatusService.CreateCollectionAsync(documentStatusForCreation);
        return Created(Url.Link("CollectionDocumentStatus", null),documentStatusDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}