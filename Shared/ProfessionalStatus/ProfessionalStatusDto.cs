namespace Shared.ProfessionalStatus;

public record ProfessionalStatusDto : ProfessionalStatusForManipulationDto
{ 
    public Guid Guid { get; set; }
}