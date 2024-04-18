using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Notification : TableBase
{
    [Column("NotificationId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Notification date is a required field.")]
    public DateTime Date { get; set; }
    
    [Required(ErrorMessage = "IsRead is a required field.")]
    public bool IsRead { get; set; }

    [ForeignKey(nameof(NotificationType))]
    [Required(ErrorMessage = "NotificationTypeId is a required field.")]
    public Guid NotificationTypeId { get; set; }
    public NotificationType? NotificationType { get; set; }
    
    //navigation
    public ICollection<UserXNotification?>? UserXNotificationCollection { get; set; }
}