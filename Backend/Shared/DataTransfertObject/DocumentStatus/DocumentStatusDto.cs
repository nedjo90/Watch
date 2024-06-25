namespace Shared.DataTransfertObject.DocumentStatus;

public record DocumentStatusDto : DocumentStatusForManipulationDto
{
    public Guid? Id { get; init; }
}