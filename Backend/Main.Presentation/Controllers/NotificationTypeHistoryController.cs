using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.NotificationTypeHistory;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationTypeHistoryController : ControllerBase
{
    private readonly IServiceManager _service;

    public NotificationTypeHistoryController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<NotificationTypeHistoryDto> notificationTypeHistoryDtos = 
            await _service.NotificationTypeHistoryService.GetAllAsync(false);
        return Ok(notificationTypeHistoryDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}