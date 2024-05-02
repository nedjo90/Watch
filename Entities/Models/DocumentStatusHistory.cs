namespace Entities.Models;

public class DocumentStatusHistory : HistoryBase
{

    public Guid DocumentStatusId { get; set; }
    public DocumentStatus DocumentStatus { get; set; }
    public string Label { get; set; }
}