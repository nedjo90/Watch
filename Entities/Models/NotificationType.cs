using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class NotificationType : BasicGenericEntity
{
    public ICollection<Notification> Notifications { get; set; }
    public ICollection<NotificationTypeHistory> NotificationTypeHistories { get; set; }
}