using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.NotificationHistory;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationHistoryController : ControllerBase
{
    private readonly IServiceManager _service;

    public NotificationHistoryController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<NotificationHistoryDto> notificationHistoryDtos = 
            await _service.NotificationHistoryService.GetAllAsync(false);
        return Ok(notificationHistoryDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}