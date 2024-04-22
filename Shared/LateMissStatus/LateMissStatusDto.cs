namespace Shared.LateMissStatus;

public record LateMissStatusDto : LateMissStatusForManipulationDto
{
    public Guid Id { get; set; }
}