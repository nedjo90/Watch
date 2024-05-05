using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class NotificationType
{
    [Column("Id")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Notification Type label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Notification Type label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Notification Type label is 2 characters")]
    public string? Label { get; set; }
    public ICollection<Notification> Notifications { get; set; }
    public ICollection<NotificationTypeHistory> NotificationTypeHistories { get; set; }
}