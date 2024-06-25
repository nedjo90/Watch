using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransfertObject.DocumentStatus;

public abstract record DocumentStatusForManipulationDto
{
    [Required(ErrorMessage = "Document Status label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Document Status label is 60 characters")]
    [MinLength(2, ErrorMessage = "Minimum length for the Document Status label is 2 characters")]
    public string? Label { get; init; }
}