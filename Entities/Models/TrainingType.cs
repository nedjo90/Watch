using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class TrainingType : TableBase
{
    [Column("TrainingTypeId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Training Type Label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Training Type Label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Training Type Label is 2 characters")]
    public string? Label { get; set; }
    
    public ICollection<DocumentTypeXTrainingType?>? DocumentTypeXTrainingTypeCollection { get; set; }
}