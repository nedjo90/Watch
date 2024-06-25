using Main.Presentation.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.LateMissStatus;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LateMissStatusController : ControllerBase
{
    private readonly IServiceManager _service;

    public LateMissStatusController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("{id:guid}", Name = "LateMissStatusById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        LateMissStatusDto? lateMissStatusDto =
            await _service.LateMissStatusService.GetByIdAsync(id, false);
        return Ok(lateMissStatusDto);
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<LateMissStatusDto> lateMissStatusDtos =
            await _service.LateMissStatusService.GetAllAsync( false);
        return Ok(lateMissStatusDtos);
    }
    
    [HttpGet("collection",Name = "CollectionLateMissStatus")]
    public async Task<IActionResult> GetCollectionAsync([FromBody]IEnumerable<Guid?> ids)
    {
        IEnumerable<LateMissStatusDto> lateMissStatusDtos =
            await _service.LateMissStatusService.GetCollectionAsync(ids, false);
        return Ok(lateMissStatusDtos);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateAsync([FromBody]LateMissStatusForCreationDto lateMissStatusForCreationDto)
    {
        LateMissStatusDto lateMissStatusDto =
            await _service.LateMissStatusService.CreateAsync(lateMissStatusForCreationDto);
        return CreatedAtRoute("LateMissStatusById", new { Id = lateMissStatusDto.Id }, lateMissStatusDto);
    }
    
        
    [HttpPost("collection", Name = "CreateCollectionLateMissStatus")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCollectionAsync([FromBody]IEnumerable<LateMissStatusForCreationDto> lateMissStatusForCreation)
    {
        IEnumerable<LateMissStatusDto> lateMissStatusDtos =
            await _service.LateMissStatusService.CreateCollectionAsync(lateMissStatusForCreation);
        return Created(Url.Link("CollectionLateMissStatus", null),lateMissStatusDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}