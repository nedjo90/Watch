using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.Training;
using Shared.DataTransfertObject.TrainingHistory;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainingHistoryController : ControllerBase
{
    private readonly IServiceManager _service;

    public TrainingHistoryController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<TrainingHistoryDto> trainingHistoryDtos =
            await _service.TrainingHistoryService.GetAllAsync(false);
        return Ok(trainingHistoryDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }

}