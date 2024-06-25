using Entities.Models;
using Main.Presentation.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.LateMiss;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LateMissController : ControllerBase
{
    private readonly IServiceManager _service;

    public LateMissController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet("{id:guid}", Name = "LateMissById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        LateMissDto lateMissDto = await _service.LateMissService.GetByIdAsync(id, false);
        return Ok(lateMissDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<LateMissDto> lateMissDtos =
            await _service.LateMissService.GetAllAsync(false);
        return Ok(lateMissDtos);
    }
    
    [HttpGet("collection",Name = "CollectionLateMiss")]
    public async Task<IActionResult> GetCollectionAsync([FromBody]IEnumerable<Guid?> ids)
    {
        IEnumerable<LateMissDto> lateMissDtos =
            await _service.LateMissService.GetCollectionAsync(ids, false);
        return Ok(lateMissDtos);
    }
    
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateAsync([FromBody]LateMissForCreationDto lateMissForCreationDto)
    {
        LateMissDto lateMissDto =
            await _service.LateMissService.CreateAsync(lateMissForCreationDto);
        return CreatedAtRoute("LateMissById", new { Id = lateMissDto.Id }, lateMissDto);
    }
    
    [HttpPost("collection", Name = "CreateCollectionLateMiss")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCollectionAsync([FromBody]IEnumerable<LateMissForCreationDto> lateMissForCreationDto)
    {
        IEnumerable<LateMissDto> lateMissDtos =
            await _service.LateMissService.CreateCollectionAsync(lateMissForCreationDto);
        return Created(Url.Link("CollectionLateMiss", null),lateMissDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}