using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.TrainingType;

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
    
    [HttpPost()]
    public async Task<IActionResult> CreateTrainingType(
        [FromBody] TrainingTypeForCreationDto trainingTypeForCreationDto)
    {
        TrainingTypeDto trainingTypeDto = await _service.TrainingTypeService.CreateAsync(trainingTypeForCreationDto);
        return CreatedAtRoute("TrainingTypeById", new { Id = trainingTypeDto.Id }, trainingTypeDto);
    }
}