using Entities.Models;
using Main.Presentation.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.ProfessionalStatus;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfessionalStatusController : ControllerBase
{
    private readonly IServiceManager _service;

    public ProfessionalStatusController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet("{id:guid}", Name = "ProfessionalStatusById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        ProfessionalStatusDto professionalStatusDto =
            await _service.ProfessionalStatusService.GetByIdAsync(id, false);
        return Ok(professionalStatusDto);
    }
    
    
    [HttpGet(Name = "AllProfessionalStatus")]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<ProfessionalStatusDto> professionalStatusDtos =
            await _service.ProfessionalStatusService.GetAllAsync(false);
        return Ok(professionalStatusDtos);
    }
    
    [HttpGet("collection",Name = "CollectionProfessionalStatus")]
    public async Task<IActionResult> GetCollectionAsync([FromBody]IEnumerable<Guid?> ids)
    {
        IEnumerable<ProfessionalStatusDto> professionalStatusDtos =
            await _service.ProfessionalStatusService.GetCollectionAsync(ids, false);
        return Ok(professionalStatusDtos);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateAsync(
        [FromBody] ProfessionalStatusForCreationDto professionalStatusForCreationDto)
    {
        ProfessionalStatusDto professionalStatusDto =
            await _service.ProfessionalStatusService.CreateAsync(professionalStatusForCreationDto);
        return CreatedAtRoute("ProfessionalStatusById", new {Id = professionalStatusDto.Id}, professionalStatusDto);
    }
    
    [HttpPost("collection", Name = "CreateCollectionProfessionalStatus")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCollectionAsync([FromBody]IEnumerable<ProfessionalStatusForCreationDto> professionalStatusForCreation)
    {
        IEnumerable<ProfessionalStatusDto> professionalStatusDtos =
            await _service.ProfessionalStatusService.CreateCollectionAsync(professionalStatusForCreation);
        return Created(Url.Link("CollectionProfessionalStatus", null),professionalStatusDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}