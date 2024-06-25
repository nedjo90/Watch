using Entities.Models;
using Main.Presentation.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.Document;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentController : ControllerBase
{
    private readonly IServiceManager _service;

    public DocumentController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet("{id:guid}", Name = "DocumentById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        DocumentDto documentDto =
            await _service.DocumentService.GetByIdAsync(id, false);
        return Ok(documentDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<DocumentDto> documentDtos =
            await _service.DocumentService.GetAllAsync(false);
        return Ok(documentDtos);
    }
    
    [HttpGet("collection",Name = "CollectionDocument")]
    public async Task<IActionResult> GetCollectionAsync([FromBody]IEnumerable<Guid?> ids)
    {
        IEnumerable<DocumentDto> documentDtos =
            await _service.DocumentService.GetCollectionAsync(ids, false);
        return Ok(documentDtos);
    }
    
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateAsync([FromBody] DocumentForCreationDto documentForCreationDto)
    {
        DocumentDto documentDto =
            await _service.DocumentService.CreateAsync(documentForCreationDto);
        return CreatedAtRoute("DocumentById", new { Id = documentDto.Id }, documentDto);
    }
    
    [HttpPost("collection", Name = "CreateCollectionDocument")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCollectionAsync([FromBody]IEnumerable<DocumentForCreationDto> documentForCreationDto)
    {
        IEnumerable<DocumentDto> documentDtos =
            await _service.DocumentService.CreateCollectionAsync(documentForCreationDto);
        return Created(Url.Link("CollectionDocument", null),documentDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}