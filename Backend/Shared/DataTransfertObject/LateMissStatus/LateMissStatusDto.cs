namespace Shared.DataTransfertObject.LateMissStatus;

public record LateMissStatusDto : LateMissStatusForManipulationDto
{
    public Guid Id { get; set; }
}