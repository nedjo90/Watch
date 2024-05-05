using System.ComponentModel.DataAnnotations;

namespace Shared.Training;

public record TrainingForManipulationDto
{
    
    // [Required(ErrorMessage = "Label is a required field.")]
    // [MinLength(2, ErrorMessage = "Minimum Length for Label is 2 characters")]
    // [MaxLength(60, ErrorMessage = "Maximum Length for Label is 60 characters")]
    // public string? Label { get; init; }
    // [Required(ErrorMessage = "Starting Date is a required field.")]
    public DateTime? StartDate { get; init; }
    [Required(ErrorMessage = "Ending Date is a required field.")]
    public DateTime? EndDate { get; init; }
    [Required(ErrorMessage = "Training Type is a required field.")]
    public Guid? TrainingTypeId { get; init; }
}