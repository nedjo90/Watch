namespace Shared.DataTransfertObject.LateMissDocument;

public record LateMissDocumentDto : LateMissDocumentForManipulationDto
{
    public Guid Id { get; set; }
}