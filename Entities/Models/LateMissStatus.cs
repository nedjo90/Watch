using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class LateMissStatus : TableBase
{
    [Column("LateMissTypeId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Late or Miss Status Label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Late or Miss Status Label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Late or Miss Status Label is 2 characters")]
    public string? Label { get; set; }
    
    public ICollection<LateMissXLateMissStatus?>? LateMissXLateMissStatusCollection { get; set; }
}