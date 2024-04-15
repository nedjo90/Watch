using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Document
{
    [Column("DocumentId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Document Label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Document Label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Document Label is 2 characters")]
    public string? Label { get; set; }
    
    [Required(ErrorMessage = "Path is a required field.")]
    [MinLength(1, ErrorMessage = "Minimum length for the Path is 2 characters")]
    public string? Path { get; set; }
    
    [Required(ErrorMessage = "Upload Date is a required field.")]
    public DateTime UploadDate { get; set; }
    
    [ForeignKey(nameof(DocumentType))]
    [Required(ErrorMessage = "Document Type Id is a required field.")]
    public Guid DocumentTypeId { get; set; }
    public DocumentType? DocumentType { get; set; }
    
    [ForeignKey(nameof(User))]
    [Required(ErrorMessage = "User Id is a required field.")]
    public Guid UserId { get; set; }
    public User? User { get; set; }
    
    //navigation
    public ICollection<DocumentXDocumentStatus?>? DocumentXDocumentStatusCollection { get; set; }

}