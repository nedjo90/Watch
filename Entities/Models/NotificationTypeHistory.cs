namespace Entities.Models;

public class NotificationTypeHistory : HistoryBase
{
    public Guid NotificationTypeId { get; set; }
    public NotificationType NotificationType { get; set; }
    public string Label { get; set; }
}