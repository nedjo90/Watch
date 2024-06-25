namespace Shared.DataTransfertObject.DocumentTypeHistory;

public record DocumentTypeHistoryDto
{
    public Guid Id { get; init; }
    public string? ModifierUserId { get; init; }
    public string? TypeOfModification { get; init; }
    public DateTime DateOfModification { get; init; }
    public Guid DocumentTypeId { get; init; }
    public string? Label { get; init; }
}