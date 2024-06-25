namespace Shared.DataTransfertObject.Training;

public record TrainingDto : TrainingForManipulationDto
{
    public Guid Id { get; init; }
}