using System.ComponentModel.DataAnnotations.Schema;


namespace Shared.TrainingTypeHistory;

public record TrainingTypeHistoryDto
{
    public string? ModifierUserId { get; set; }
    public TypeOfModification TypeOfModification { get; set; }
    public DateTime DateOfModification { get; set; } = DateTime.UtcNow;
    public Guid TrainingTypeId { get; set; }
    public string? Label { get; set; }
}