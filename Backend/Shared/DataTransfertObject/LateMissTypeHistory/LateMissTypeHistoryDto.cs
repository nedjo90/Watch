namespace Shared.DataTransfertObject.LateMissTypeHistory;

public record LateMissTypeHistoryDto
{
    public Guid Id { get; init; }
    public string? ModifierUserId { get; init; }
    public string? TypeOfModification { get; init; }
    public DateTime DateOfModification { get; init; }
    public Guid LateMissTypeId { get; init; }
    public string? Label { get; init; }
}