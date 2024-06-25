namespace Shared.DataTransfertObject.LateMiss;

public record LateMissDto : LateMissForManipulationDto
{
    public Guid Id { get; init; }
}