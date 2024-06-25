

namespace Shared.DataTransfertObject.DocumentStatusHistory;

public record DocumentStatusHistoryDto
{
    public Guid Id { get; init; }
    public string? ModifierUserId { get; init; }
    public string? TypeOfModification { get; init; }
    public DateTime DateOfModification { get; init; }
    public Guid DocumentStatusId { get; init; }
    public string? Label { get; init; }
}