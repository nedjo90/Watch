using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class DocumentXDocumentStatus  : TableBase
{
    [Column("DocumentXDocumentStatusId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "DocumentId")]
    public Guid DocumentId { get; set; }
    public Document? Document { get; set; }

    [Required(ErrorMessage = "DocumentStatusId")]
    public Guid DocumentStatusId { get; set; }
    public DocumentStatus? DocumentStatus { get; set; }
    
    [Required(ErrorMessage = "StatusDate")]
    public DateTime StatusDate { get; set; }
    public string? Comment { get; set; }
}