using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class DocumentType
{
    [Column("Id")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Document Type label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Document Type label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Document Type label is 2 characters")]
    public string? Label { get; set; }
    //navigation
    public ICollection<TrainingType> TrainingTypes { get; set; }
    public ICollection<Document> Documents { get; set; }
    public ICollection<DocumentTypeHistory> DocumentTypeHistories { get; set; }
}