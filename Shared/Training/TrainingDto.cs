namespace Shared.Training;

public record TrainingDto : TrainingForManipulationDto
{
    public Guid Id { get; init; }
}