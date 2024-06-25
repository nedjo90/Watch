using Entities.Models;
using Main.Presentation.ActionFilter;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.Notification;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly IServiceManager _service;

    public NotificationController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet("{id:guid}", Name = "NotificationById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        NotificationDto? notificationDto =
            await _service.NotificationService.GetByIdAsync(id, false);
        return Ok(notificationDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<NotificationDto> notificationDtos =
            await _service.NotificationService.GetAllAsync(false);
        return Ok(notificationDtos);
    }
    
    [HttpGet("collection",Name = "CollectionNotification")]
    public async Task<IActionResult> GetCollectionAsync([FromBody]IEnumerable<Guid?> ids)
    {
        IEnumerable<NotificationDto> notificationDtos =
            await _service.NotificationService.GetCollectionAsync(ids, false);
        return Ok(notificationDtos);
    }
    
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateAsync([FromBody]NotificationForCreationDto notificationForCreationDto)
    {
        NotificationDto notificationDto =
            await _service.NotificationService.CreateAsync(notificationForCreationDto);
        return CreatedAtRoute("NotificationById", new { Id = notificationDto.Id }, notificationDto);
    }
    
    [HttpPost("collection", Name = "CreateCollectionNotification")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCollectionAsync([FromBody]IEnumerable<NotificationForCreationDto> notificationForCreationDto)
    {
        IEnumerable<NotificationDto> notificationDtos =
            await _service.NotificationService.CreateCollectionAsync(notificationForCreationDto);
        return Created(Url.Link("CollectionNotification", null),notificationDtos);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}