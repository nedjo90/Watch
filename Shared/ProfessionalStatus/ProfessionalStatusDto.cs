namespace Shared.ProfessionalStatus;

public record ProfessionalStatusDto : ProfessionalStatusForManipulationDto
{ 
    public Guid Id { get; set; }
}