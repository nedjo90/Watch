using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransfertObject.TrainingType;

public record TrainingTypeForManipulation
{
    [Required(ErrorMessage = "Training Type label is a required field.")]
    [MinLength(2, ErrorMessage = "Minimum Length for Training Type label is 2 characters")]
    [MaxLength(60, ErrorMessage = "Maximum Length for Training Type label is 60 characters")]
    public string? Label { get; init; }
}