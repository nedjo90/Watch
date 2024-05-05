using System.ComponentModel.DataAnnotations;

namespace Shared.ProfessionalStatus;

public record ProfessionalStatusForManipulationDto
{
    [Required(ErrorMessage = "Professional Status label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Professional Status label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Professional Status label is 2 characters")]
    public string? Label { get; set; }
}