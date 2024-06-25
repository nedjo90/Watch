namespace Entities.Models;

public class DocumentTypeHistory : HistoryBase
{
    public Guid DocumentTypeId { get; set; }
    public DocumentType DocumentType { get; set; }
    public string Label { get; set; }
}