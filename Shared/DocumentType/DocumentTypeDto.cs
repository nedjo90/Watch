namespace Shared.DocumentType;

public record DocumentTypeDto : DocumentTypeForManipulationDto
{
    public Guid Id { get; init; }
}