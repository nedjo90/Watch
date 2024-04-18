using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Training : TableBase
{
    [Column("TrainingId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Training Start Date is a required field.")]
    public DateTime StartDate { get; set; }
    
    [Required(ErrorMessage = "Training End Date is a required field.")]
    public DateTime EndDate { get; set; }
    
    [ForeignKey(nameof(TrainingType))]
    [Required(ErrorMessage = "TrainingTypeId is a required field.")]
    public Guid TrainingTypeId { get; set; }
    public TrainingType? TrainingType { get; set; }
    
}