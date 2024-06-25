namespace Shared.DataTransfertObject.TrainingTypeHistory;

public record TrainingTypeHistoryDto
{
    public string? ModifierUserId { get; set; }
    public string? TypeOfModification { get; set; }
    public DateTime DateOfModification { get; set; } = DateTime.UtcNow;
    public Guid TrainingTypeId { get; set; }
    public string? Label { get; set; }
}