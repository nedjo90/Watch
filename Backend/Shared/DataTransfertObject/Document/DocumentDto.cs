namespace Shared.DataTransfertObject.Document;

public record DocumentDto : DocumentForManipulationDto
{
    public Guid? Id { get; init; }
}