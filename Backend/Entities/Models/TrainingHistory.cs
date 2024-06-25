namespace Entities.Models;

public class TrainingHistory : HistoryBase
{
    public Guid TrainingId { get; set; }
    public Training Training { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid TrainingTypeId { get; set; }
}