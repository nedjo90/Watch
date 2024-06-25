using Entities.Models;
using Main.Presentation.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Service.Contracts;
using Shared.DataTransfertObject.NotificationType;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationTypeController : ControllerBase
{
    private readonly IServiceManager _service;

    public NotificationTypeController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet("{id:guid}", Name = "NotificationTypeById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        NotificationTypeDto notificationTypeDto =
            await _service.NotificationTypeService.GetByIdAsync(id, false);
        return Ok(notificationTypeDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<NotificationTypeDto> notificationTypeDtos =
            await _service.NotificationTypeService.GetAllAsync(false);
        return Ok(notificationTypeDtos);
    }
    
    [HttpGet("collection",Name = "CollectionNotificationType")]
    public async Task<IActionResult> GetCollectionAsync([FromBody]IEnumerable<Guid?> ids)
    {
        IEnumerable<NotificationTypeDto> notificationTypeDtos =
            await _service.NotificationTypeService.GetCollectionAsync(ids, false);
        return Ok(notificationTypeDtos);
    }
    
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateAsync([FromBody]NotificationTypeForCreationDto notificationTypeForCreationDto)
    {
        NotificationTypeDto notificationTypeDto =
            await _service.NotificationTypeService.CreateAsync(notificationTypeForCreationDto);
        return CreatedAtRoute("NotificationTypeById", new { Id = notificationTypeDto.Id }, notificationTypeDto);
    }
    
    [HttpPost("collection", Name = "CreateCollectionNotificationType")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCollectionAsync([FromBody]IEnumerable<NotificationTypeForCreationDto> notificationTypeForCreation)
    {
        IEnumerable<NotificationTypeDto> notificationTypeDtos =
            await _service.NotificationTypeService.CreateCollectionAsync(notificationTypeForCreation);
        return Created(Url.Link("CollectionNotificationType", null),notificationTypeDtos);
    }

    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}