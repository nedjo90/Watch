namespace Shared.DataTransfertObject.NotificationHistory;

public record NotificationHistoryDto
{
    public Guid Id { get; init; }
    public string? ModifierUserId { get; init; }
    public string? TypeOfModification { get; init; }
    public DateTime DateOfModification { get; init; }
    public Guid NotificationId { get; init; }
    public DateTime? NotificationDate { get; init; }
    public bool? IsRead { get; init; }
    public Guid? NotificationTypeId { get; init; }
}