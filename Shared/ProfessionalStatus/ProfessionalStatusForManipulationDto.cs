using System.ComponentModel.DataAnnotations;

namespace Shared.ProfessionalStatus;

public abstract record ProfessionalStatusForManipulationDto
{
    [Required(ErrorMessage = "Label is a required field.")]
    [MinLength(2, ErrorMessage = "Minimum Length for Label is 2 characters")]
    [MaxLength(60, ErrorMessage = "Maximum Length for Label is 60 characters")]
    public string? Label { get; set; }
}