namespace Shared.DataTransfertObject.TrainingType;

public record TrainingTypeDto : TrainingTypeForManipulation
{
    public Guid Id { get; init; }
}