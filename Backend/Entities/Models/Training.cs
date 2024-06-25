using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Training
{
    [Column("TrainingId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Training Start Date is a required field.")]
    public DateTime StartDate { get; set; }
    
    [Required(ErrorMessage = "Training End Date is a required field.")]
    public DateTime EndDate { get; set; }
    
    [Required(ErrorMessage = "TrainingTypeId is a required field.")]
    public Guid TrainingTypeId { get; set; }
    public TrainingType? TrainingType { get; set; }

    public ICollection<User> Users { get; set; }
    public ICollection<TrainingHistory> TrainingHistories { get; set; }
}