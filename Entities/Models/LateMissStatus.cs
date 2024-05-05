using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class LateMissStatus
{
    [Column("Id")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Late Miss Status label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Late Miss Status label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Late Miss Status label is 2 characters")]
    public string? Label { get; set; }
    
    public ICollection<LateMiss> LateMisses { get; set; }
    public ICollection<LateMissStatusHistory> LateMissStatusHistories { get; set; }
}