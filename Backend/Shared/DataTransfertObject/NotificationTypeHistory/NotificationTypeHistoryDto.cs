namespace Shared.DataTransfertObject.NotificationTypeHistory;

public record NotificationTypeHistoryDto
{
    public Guid Id { get; init; }
    public string? ModifierUserId { get; init; }
    public string? TypeOfModification { get; init; }
    public DateTime DateOfModification { get; init; }
    public Guid NotificationTypeId { get; init; }
    public string? Label { get; init; }
}