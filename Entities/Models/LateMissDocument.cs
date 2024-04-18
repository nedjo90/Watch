using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class LateMissDocument  : TableBase
{
    [Column("LateMissDocumentId")]
    public Guid Id {get; set;}
    
    [Required(ErrorMessage = "Path is a required field.")]
    [MinLength(1, ErrorMessage = "Minimum length for the Path is 2 characters")]
    public string? Path { get; set; }
    
    [Required(ErrorMessage = "Label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Label is 2 characters")]
    public string? Label { get; set; }
    
    [Required(ErrorMessage = "Upload Date is a required field.")]
    public DateTime UploadDate { get; set; }
    
    [ForeignKey(nameof(LateMiss))]
    [Required(ErrorMessage = "LateMissId is a required field.")]
    public Guid LateMissId { get; set; }
    public LateMiss? LateMiss { get; set; }
}