using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransfertObject.LateMissStatus;

public record LateMissStatusForManipulationDto
{
    [Required(ErrorMessage = "Late Miss Status label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Late Miss Status label is 60 characters")]
    [MinLength(2, ErrorMessage = "Minimum length for the Late Miss Status label is 2 characters")]
    public string? Label { get; set; }
}