using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class LateMiss
{
    
    [Column("LateMissId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Late or Miss Declaration Date is a required field.")]
    public DateTime DeclarationDate { get; set; }
    
    [Required(ErrorMessage = "Late or Miss Start Date is a required field.")]
    public DateTime StartDate { get; set; }
    
    [Required(ErrorMessage = "Late or Miss End Date is a required field.")]
    public DateTime EndDate { get; set; }
    
    [ForeignKey(nameof(LateMissType))]
    [Required(ErrorMessage = "LateMissTypeId is a required field.")]
    public Guid LateMissTypeId { get; set; }
    public LateMissType? LateMissType { get; set; }
    
    [ForeignKey(nameof(User))]
    [Required(ErrorMessage = "UserId is a required field.")]
    public Guid UserId { get; set; }
    public User? User { get; set; }
    
    //Navigation
    public ICollection<LateMissXLateMissStatus?>? LateMissXLateMissStatusCollection { get; set; }
}