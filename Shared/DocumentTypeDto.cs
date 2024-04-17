namespace Shared;

public record DocumentTypeDto : DocumentTypeForManipulationDto
{
    public Guid Id { get; init; }
}