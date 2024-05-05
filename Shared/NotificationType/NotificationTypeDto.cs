
namespace Shared.NotificationType;

public record NotificationTypeDto : NotificationTypeForManipulationDto
{
    public Guid Id { get; set; }
}