namespace Shared.DataTransfertObject.TrainingHistory;

public record TrainingHistoryDto
{
    public string? ModifierUserId { get; init; }
    public string? TypeOfModification { get; init; }
    public DateTime DateOfModification { get; init; }
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public Guid? TrainingTypeId { get; init; }
}