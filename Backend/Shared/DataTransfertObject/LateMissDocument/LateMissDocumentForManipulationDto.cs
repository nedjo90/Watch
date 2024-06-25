using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransfertObject.LateMissDocument;

public record LateMissDocumentForManipulationDto
{
    [Required(ErrorMessage = "Late Miss Document path is a required field.")]
    [MinLength(1, ErrorMessage = "Minimum length for the Path is 2 characters")]
    public string? Path { get; init; }
    
    [Required(ErrorMessage = "Late Miss label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Label is 2 characters")]
    public string? Label { get; init; }

    [Required(ErrorMessage = "Late Miss Id is a required field.")]
    public Guid? LateMissId { get; init; }
}