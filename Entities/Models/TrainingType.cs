using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class TrainingType
{
    [Column("Id")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Training Type label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Training Type label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Training Type label is 2 characters")]
    public string? Label { get; set; }
    
    public ICollection<DocumentType> DocumentTypes { get; set; }
    public ICollection<TrainingTypeHistory> TrainingTypeHistories { get; set; }
}