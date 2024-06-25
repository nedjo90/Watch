namespace Shared.DataTransfertObject.LateMissStatusHistory;

public record LateMissStatusHistoryDto
{
    public Guid Id { get; init; }
    public string? ModifierUserId { get; init; }
    public string? TypeOfModification { get; init; }
    public DateTime DateOfModification { get; init; }
    public Guid LateMissStatusId { get; init; }
    public string? Label { get; init; }
}