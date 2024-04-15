using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class DocumentStatus
{
    [Column("DocumentStatusId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Document Status Label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Document Status Label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Document Status Label is 2 characters")]
    public string? Label { get; set; }
    
    //navigation
    public ICollection<DocumentXDocumentStatus?>? DocumentXDocumentStatusCollection { get; set; }
}