using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

// ReSharper disable once ClassNeverInstantiated.Global
public class DocumentTypeXTrainingType : TableBase
{
    [Column("DocumentTypeXTrainingTypeId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "DocumentTypeId is a required field.")]
    public Guid DocumentTypeId { get; set; }
    public DocumentType? DocumentType { get; set; }

    [Required(ErrorMessage = "TrainingTypeId is a required field.")]
    public Guid TrainingTypeId { get; set; }
    public TrainingType? TrainingType { get; set; }
    
    [Required(ErrorMessage = "IsRequired is a required field.")]
    public bool IsRequired { get; set; }
}