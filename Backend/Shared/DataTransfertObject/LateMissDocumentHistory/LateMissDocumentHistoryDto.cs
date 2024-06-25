namespace Shared.DataTransfertObject.LateMissDocumentHistory;

public record LateMissDocumentHistoryDto
{
    public Guid Id { get; init; }
    public string? ModifierUserId { get; init; }
    public string? TypeOfModification { get; init; }
    public DateTime DateOfModification { get; init; }
    public Guid LateMissDocumentId { get; init; }
    public string? Path { get; init; }
    public string? Label { get; init; }
    public Guid LateMissId { get; init; }
}