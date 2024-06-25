using Main.Presentation.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.Training;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainingController : ControllerBase
{
    private readonly IServiceManager _service;

    public TrainingController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet("{id:guid}", Name = "TrainingById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        TrainingDto trainingDto =
            await _service.TrainingService.GetByIdAsync(id, false);
        return Ok(trainingDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<TrainingDto> trainingDtos =
            await _service.TrainingService.GetAllAsync(false);
        return Ok(trainingDtos);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateTraining([FromBody]TrainingForCreationDto trainingForCreationDto)
    {
        TrainingDto trainingDto = await _service.TrainingService.CreateTrainingAsync(trainingForCreationDto);
        return CreatedAtRoute("TrainingById", new { Id = trainingDto.Id }, trainingDto);
    }
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}