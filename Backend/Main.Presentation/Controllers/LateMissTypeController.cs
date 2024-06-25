using Entities.Models;
using Main.Presentation.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.LateMissType;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LateMissTypeController : ControllerBase
{
    private readonly IServiceManager _service;

    public LateMissTypeController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("{id:guid}", Name = "LateMissTypeById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        LateMissTypeDto? lateMissTypeDto =
            await _service.LateMissTypeService.GetByIdAsync(id, false);
        return Ok(lateMissTypeDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(Guid id)
    {
        IEnumerable<LateMissTypeDto> lateMissTypeDtos =
            await _service.LateMissTypeService.GetAllAsync( false);
        return Ok(lateMissTypeDtos);
    }
    
    [HttpGet("collection",Name = "CollectionLateMissType")]
    public async Task<IActionResult> GetCollectionAsync([FromBody]IEnumerable<Guid?> ids)
    {
        IEnumerable<LateMissTypeDto> lateMissTypeDtos =
            await _service.LateMissTypeService.GetCollectionAsync(ids, false);
        return Ok(lateMissTypeDtos);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateAsync([FromBody] LateMissTypeForCreationDto lateMissTypeForCreationDto)
    {
        LateMissTypeDto lateMissTypeDto =
            await _service.LateMissTypeService.CreateAsync(lateMissTypeForCreationDto);
        return CreatedAtRoute("LateMissTypeById", new { Id = lateMissTypeDto.Id }, lateMissTypeDto);
    }
    
    [HttpPost("collection", Name = "CreateCollectionLateMissType")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCollectionAsync([FromBody]IEnumerable<LateMissTypeForCreationDto> lateMissTypeForCreation)
    {
        IEnumerable<LateMissTypeDto> lateMissTypeDtos =
            await _service.LateMissTypeService.CreateCollectionAsync(lateMissTypeForCreation);
        return Created(Url.Link("CollectionLateMissType", null),lateMissTypeDtos);
    }
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}