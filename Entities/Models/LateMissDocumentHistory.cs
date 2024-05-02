namespace Entities.Models;

public class LateMissDocumentHistory : HistoryBase
{
    public Guid LateMissDocumentId {get; set;}
    public LateMissDocument LateMissDocument {get; set;}
    public string Path { get; set; }
    public string Label { get; set; }
    public Guid LateMissId { get; set; }
}