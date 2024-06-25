namespace Shared.DataTransfertObject.DocumentHistory;

public record DocumentHistoryDto
{
    public Guid Id { get; init; }
    public string? ModifierUserId { get; init; }
    public string? TypeOfModification { get; init; }
    public DateTime DateOfModification { get; init; }
    public string? Label { get; init; }
    public string? Path { get; init; }
    public Guid? DocumentTypeId { get; init; }
    public Guid? DocumentStatusId { get; init; }
    public string? UserId { get; init; }
}