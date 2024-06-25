using Entities.Models;
using Main.Presentation.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.LateMissDocument;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LateMissDocumentController : ControllerBase
{
    private readonly IServiceManager _service;

    public LateMissDocumentController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet("{id:guid}", Name = "LateMissDocumentById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        LateMissDocumentDto? lateMissDocumentDto =
            await _service.LateMissDocumentService.GetByIdAsync(id, false);
        return Ok(lateMissDocumentDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<LateMissDocumentDto> lateMissDocumentDtos =
            await _service.LateMissDocumentService.GetAllAsync(false);
        return Ok(lateMissDocumentDtos);
    }
    
    [HttpGet("collection",Name = "CollectionLateMissDocument")]
    public async Task<IActionResult> GetCollectionAsync([FromBody]IEnumerable<Guid?> ids)
    {
        IEnumerable<LateMissDocumentDto> lateMissDocumentDtos =
            await _service.LateMissDocumentService.GetCollectionAsync(ids, false);
        return Ok(lateMissDocumentDtos);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateAsync([FromBody] LateMissDocumentForCreationDto lateMissDocumentForCreationDto)
    {
        LateMissDocumentDto lateMissDocumentDto =
            await _service.LateMissDocumentService.CreateAsync(lateMissDocumentForCreationDto);
        return CreatedAtRoute("LateMissDocumentById", new { Id = lateMissDocumentDto.Id }, lateMissDocumentDto);
    }

    [HttpPost("collection", Name = "CreateCollectionLateMissDocument")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCollectionAsync([FromBody]IEnumerable<LateMissDocumentForCreationDto> lateMissDocumentForCreationDto)
    {
        IEnumerable<LateMissDocumentDto> lateMissDocumentDtos =
            await _service.LateMissDocumentService.CreateCollectionAsync(lateMissDocumentForCreationDto);
        return Created(Url.Link("CollectionLateMissDocument", null),lateMissDocumentDtos);
    }

    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}