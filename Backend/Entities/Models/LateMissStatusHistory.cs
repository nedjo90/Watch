namespace Entities.Models;

public class LateMissStatusHistory : HistoryBase
{

    public Guid LateMissStatusId { get; set; }
    public LateMissStatus LateMissStatus { get; set; }
    public string Label { get; set; }
}