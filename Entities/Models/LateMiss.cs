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
    
    public Guid LateMissTypeId { get; set; }

    public LateMissType LateMissType { get; set; }

    public Guid LateMissStatusId { get; set; }

    public LateMissStatus LateMissStatus { get; set; }
    
    public string? UserId { get; set; }

    public User? User { get; set; }
    
    public ICollection<LateMissDocument> LateMissDocuments { get; set; }
    public ICollection<LateMissHistory> LateMissHistories { get; set; }

}
