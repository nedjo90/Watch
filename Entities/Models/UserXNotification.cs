using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class UserXNotification
{
    [Column("UserXNotificationId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "UserId is a required field.")]
    public Guid UserId { get; set; }
    public User? User { get; set; }

    [Required(ErrorMessage = "NotificationId is a required field.")]
    public Guid NotificationId { get; set; }
    public Notification? Notification { get; set; }
}