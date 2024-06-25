using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransfertObject.Notification;

public record NotificationForManipulationDto
{
    [Required(ErrorMessage = "Notification date is a required field.")]
    public DateTime? NotificationDate { get; init; }
    
    [Required(ErrorMessage = "IsRead is a required field.")]
    public bool? IsRead { get; init; }
    
    [Required(ErrorMessage = "NotificationTypeId is a required field.")]
    public Guid? NotificationTypeId { get; init; }
    
    [Required(ErrorMessage = "User Id is a required field.")]
    public Guid? UserId { get; set; }
}