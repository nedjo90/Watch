namespace Shared.BasicGeneric;

public abstract record BasicGenericDto : BasicGenericForManipulationDto
{
    public Guid Id { get; init; }
}