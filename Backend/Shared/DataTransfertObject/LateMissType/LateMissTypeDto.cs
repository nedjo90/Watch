namespace Shared.DataTransfertObject.LateMissType;

public record LateMissTypeDto : LateMissTypeForManipulationDto
{
    public Guid Id { get; set; }
}