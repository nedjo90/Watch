using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class UserXTraining
{
    [Column("UserXTrainingId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "UserId is a required field.")]
    public Guid UserId { get; set; }
    public User? User { get; set; }

    [Required(ErrorMessage = "TrainingId is a required field.")]
    public Guid TrainingId { get; set; }
    public Training? Training { get; set; }
    
}