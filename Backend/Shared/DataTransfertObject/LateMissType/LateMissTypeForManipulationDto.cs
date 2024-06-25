using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransfertObject.LateMissType;

public record LateMissTypeForManipulationDto
{
    [Required(ErrorMessage = "Late Miss Type label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Late Miss Type label is 60 characters")]
    [MinLength(2, ErrorMessage = "Minimum length for the Late Miss Type label is 2 characters")]
    public string? Label { get; set; }
}