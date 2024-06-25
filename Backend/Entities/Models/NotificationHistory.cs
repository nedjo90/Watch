namespace Entities.Models;

public class NotificationHistory : HistoryBase
{
    public Guid NotificationId { get; set; }
    public Notification Notification { get; set; }
    public DateTime NotificationDate { get; set; }
    public bool IsRead { get; set; }
    public Guid NotificationTypeId { get; set; }
}