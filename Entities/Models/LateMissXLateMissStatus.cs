using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class LateMissXLateMissStatus : TableBase
{
    [Column("LateMissXLateMissStatusId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "LateMissId is a required field.")]
    public Guid LateMissId { get; set; }
    public LateMiss? LateMiss { get; set; }

    [Required(ErrorMessage = "LateMissStatusId is a required field.")]
    public Guid LateMissStatusId { get; set; }
    public LateMissStatus? LateMissStatus { get; set; }
}