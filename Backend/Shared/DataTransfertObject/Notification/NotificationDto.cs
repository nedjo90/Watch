namespace Shared.DataTransfertObject.Notification;

public record NotificationDto : NotificationForManipulationDto
{
    public Guid Id { get; init; }
}