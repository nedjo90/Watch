using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransfertObject.Training;

public record TrainingForManipulationDto
{
    [Required(ErrorMessage = "Starting Date is a required field.")]
    public DateTime StartDate { get; init; }

    [Required(ErrorMessage = "Ending Date is a required field.")]
    public DateTime EndDate { get; init; }

    [Required(ErrorMessage = "Training Type is a required field.")]
    public Guid TrainingTypeId { get; init; }
}