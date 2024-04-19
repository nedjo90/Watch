using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public abstract class TableBase
{
    [Required(ErrorMessage = "CreatedDate is a required field.")]
    public DateTime CreatedDate { get; set; }
    [Required(ErrorMessage = "CreatedBy is a required field.")]
    public Guid CreatedBy { get; set; }

    [Required(ErrorMessage = "UpdateDate is a required field.")]
    public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    [Required(ErrorMessage = "UpdateBy is a required field.")]
    public Guid UpdateBy { get; set; }
}