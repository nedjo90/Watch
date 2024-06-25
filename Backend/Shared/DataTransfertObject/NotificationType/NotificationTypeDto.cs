namespace Shared.DataTransfertObject.NotificationType;

public record NotificationTypeDto : NotificationTypeForManipulationDto
{
    public Guid Id { get; set; }
}