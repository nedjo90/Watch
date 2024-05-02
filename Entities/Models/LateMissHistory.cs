namespace Entities.Models;

public class LateMissHistory : HistoryBase
{

    public Guid LateMissId { get; set; }
    public LateMiss LateMiss { get; set; }
    public DateTime DeclarationDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid LateMissTypeId { get; set; }
    public Guid LateMissStatusId { get; set; }
}