namespace Entities.Models;

public class TrainingTypeHistory : HistoryBase
{
    public Guid TrainingTypeId { get; set; }
    public TrainingType TrainingType { get; set; }
    public string Label { get; set; }
}