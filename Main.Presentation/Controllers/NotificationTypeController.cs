using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.NotificationType;

namespace Main.Presentation.Controllers;

[Route("api/notificationtype")]
[ApiController]
public class NotificationTypeController : BasicGenericController<NotificationType, NotificationTypeDto, NotificationTypeForCreationDto, NotificationTypeForUpdateDto>
{
    public NotificationTypeController(IServiceManagerBasicGeneric<NotificationType, NotificationTypeDto, NotificationTypeForCreationDto, NotificationTypeForUpdateDto> serviceManagerBasicGeneric)
        : base(serviceManagerBasicGeneric)
    {
    }


}