using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.Training;
using Shared.DataTransfertObject.TrainingTypeHistory;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainingTypeHistoryController : ControllerBase
{
    private readonly IServiceManager _service;

    public TrainingTypeHistoryController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<TrainingTypeHistoryDto> trainingTypeHistoryDtos =
            await _service.TrainingTypeHistoryService.GetAllAsync(false);
        return Ok(trainingTypeHistoryDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}