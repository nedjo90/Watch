using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public abstract class BasicGenericEntity : TableBase
{
    [Column("Id")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Label is 2 characters")]
    public string? Label { get; set; }
}