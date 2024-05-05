using System.ComponentModel.DataAnnotations;

namespace Shared.NotificationType;

public record NotificationTypeForManipulationDto
{
    [Required(ErrorMessage = "Notification Type label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Notification Type label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Notification Type label is 2 characters")]
    public string? Label { get; set; }
}