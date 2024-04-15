using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class DocumentType
{
    [Column("DocumentTypeId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Document Type is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Document Type is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Document Type is 2 characters")]
    public string? Label { get; set; }
    
    //navigation
    public ICollection<DocumentTypeXTrainingType?>? DocumentTypeXTrainingTypeCollection { get; set; }
}