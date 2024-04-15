using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class NotificationType
{
    [Column("NotificationTypeId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Notification Type Label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Notification Type Label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Notification Type Label is 2 characters")]
    public string? Label { get; set; }
}