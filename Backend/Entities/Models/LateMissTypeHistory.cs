namespace Entities.Models;

public class LateMissTypeHistory : HistoryBase
{

    public Guid LateMissTypeId { get; set; }
    public LateMissType LateMissType { get; set; }
    public string Label { get; set; }
}