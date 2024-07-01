using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransfertObject.Document;

public record DocumentForManipulationDto
{
    [Required(ErrorMessage = "Document Label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Document Label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Document Label is 2 characters")]
    public string? Label { get; init; }

    public string? Path { get; init; }
    
    [Required(ErrorMessage = "Document Type Id is a required field.")]
    public Guid? DocumentTypeId { get; init; }
    
    [Required(ErrorMessage = "Document Type Id is a required field.")]
    public Guid? DocumentStatusId { get; init; }

    //[Required(ErrorMessage = "User Id is a required field.")]
    public string? UserId { get; init; } = "";
}