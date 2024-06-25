using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransfertObject.LateMiss;

public record LateMissForManipulationDto
{
    [Required(ErrorMessage = "Late or Miss Declaration Date is a required field.")]
    public DateTime DeclarationDate { get; init; }

    [Required(ErrorMessage = "Late or Miss Start Date is a required field.")]
    public DateTime? StartDate { get; init; }
    
    [Required(ErrorMessage = "Late or Miss End Date is a required field.")]
    public DateTime? EndDate { get; init; }

    [Required(ErrorMessage = "Late or Miss Type Id is a required field.")]
    public Guid? LateMissTypeId { get; init; }
    
    [Required(ErrorMessage = "Late or Miss Status Id is a required field.")]
    public Guid? LateMissStatusId { get; init; }
    
    [Required(ErrorMessage = "Late or Miss Status User Id is a required field.")]
    public string? UserId { get; set; }
}