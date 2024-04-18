using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class ProfessionalStatus : TableBase
{
    [Column("IdProfessionalStatus")]
    public Guid Id {get; set;}

    [Required(ErrorMessage = "Professional Status Label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Professional Status Label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Professional Status Label is 2 characters")]
    public string? Label { get; set; }
}