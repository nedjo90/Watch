using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransfertObject.DocumentType;

public record DocumentTypeForManipulationDto
{
    [Required(ErrorMessage = "Document Type label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Document Type label is 60 characters")]
    [MinLength(2, ErrorMessage = "Minimum length for the Document Type label is 2 characters")]
    public string? Label { get; set; }
}