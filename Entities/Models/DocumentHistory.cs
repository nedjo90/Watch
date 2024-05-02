using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models;

public class DocumentHistory : HistoryBase
{
    public Guid DocumentId { get; set; }
    public Document Document { get; set; }
    public string Label { get; set; }
    public string Path { get; set; }
    public Guid DocumentTypeId { get; set; }
    public Guid DocumentStatusId { get; set; }
}