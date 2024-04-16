namespace Shared;

public record DocumentTypeDto
{
    public Guid Id { get; init; }
    public string? Label { get; init; }
}