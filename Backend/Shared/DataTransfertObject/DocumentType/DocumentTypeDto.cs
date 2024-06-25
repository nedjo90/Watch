namespace Shared.DataTransfertObject.DocumentType;

public record DocumentTypeDto : DocumentTypeForManipulationDto
{
    public Guid? Id { get; init; }
}