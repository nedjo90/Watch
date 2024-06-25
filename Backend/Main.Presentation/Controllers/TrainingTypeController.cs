using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.TrainingType;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainingTypeController : ControllerBase
{
    private readonly IServiceManager _service;

    public TrainingTypeController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet("{id:guid}", Name = "TrainingTypeById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        TrainingTypeDto trainingDto =
            await _service.TrainingTypeService.GetByIdAsync(id, false);
        return Ok(trainingDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<TrainingTypeDto> trainingTypeDtos =
            await _service.TrainingTypeService.GetAllAsync(false);
        return Ok(trainingTypeDtos);
    }
    
    [HttpPost()]
    public async Task<IActionResult> CreateTrainingType(
        [FromBody] TrainingTypeForCreationDto trainingTypeForCreationDto)
    {
        TrainingTypeDto trainingTypeDto = await _service.TrainingTypeService.CreateAsync(trainingTypeForCreationDto);
        return CreatedAtRoute("TrainingTypeById", new { Id = trainingTypeDto.Id }, trainingTypeDto);
    }
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}